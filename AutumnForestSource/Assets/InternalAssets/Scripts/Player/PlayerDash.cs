using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace AutumnForest.Player
{
    [RequireComponent(typeof(PlayerMovable))]

    public sealed class PlayerDash : MonoBehaviour
    {
        private enum DashState
        {
            None,
            NowDashing,
            Culldown
        }

        //dash params
        [SerializeField] private float dashSpeed = 5f;
        [SerializeField] private float dashDuration = 1f;
        [SerializeField] private int dashCulldown = 1000;
        [SerializeField] private int layerIndex = 10;

        [NaughtyAttributes.ReadOnly] private DashState dashState;
        //events
        private UnityEvent OnDash = new();
        private UnityEvent AfterDash = new();
        //some components
        private Rigidbody2D playerRigidbody;
        private Vector2 movement;

        private void OnEnable()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();

            GetComponent<PlayerMovable>().OnMoved += SetMovement;
            OnDash.AddListener(delegate { GetComponent<PlayerMovable>().IsStopped = true; });
            AfterDash.AddListener(delegate { GetComponent<PlayerMovable>().IsStopped = false; });

            GlobalServiceLocator.GetService<PlayerInput>().Inputs.Dash.performed += StartDash;
        }
        private void OnDisable() => GlobalServiceLocator.GetService<PlayerInput>().Inputs.Dash.performed -= StartDash;

        private void SetMovement(Vector2 newMovement) => movement = newMovement;
        private void StartDash(InputAction.CallbackContext context)
        {
            //деш нужно будет переписать
            float layerMaskTransitionDelay = 0.7f;

            if (movement != Vector2.zero && dashState == DashState.None)
            {
                OnDash.Invoke();
                Dashing();
            }

            async UniTaskVoid Dashing()
            {
                dashState = DashState.NowDashing;
                int defaultLayer = gameObject.layer;
                gameObject.layer = layerIndex;

                float startTime = Time.time;
                Vector2 movementOnDash = movement *= 10;

                GlobalServiceLocator.GetService<PlayerMovable>().enabled = false;

                while (Time.time <= startTime + dashDuration)
                {
                    playerRigidbody.velocity = movementOnDash * dashSpeed;
                    await UniTask.WaitForFixedUpdate();
                }

                AfterDash.Invoke();

                GlobalServiceLocator.GetService<PlayerMovable>().enabled = true;
                DashCulldown();
                await UniTask.Delay(TimeSpan.FromSeconds(layerMaskTransitionDelay));
                gameObject.layer = defaultLayer;
            }
            async void DashCulldown()
            {
                dashState = DashState.Culldown;
                await UniTask.Delay(dashCulldown);
                dashState = DashState.None;
            }
        }
    }
}