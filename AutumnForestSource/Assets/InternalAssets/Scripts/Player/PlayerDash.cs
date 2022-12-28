using System.Collections;
using System.Threading.Tasks;
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

            GetComponent<PlayerMovable>().OnMove.AddListener(SetMovement);
            OnDash.AddListener(delegate { GetComponent<PlayerMovable>().IsStopped = true; });
            AfterDash.AddListener(delegate { GetComponent<PlayerMovable>().IsStopped = false; });

            ServiceLocator.GetService<PlayerInput>().Player.Dash.performed += StartDash;
        }
        private void OnDisable() => ServiceLocator.GetService<PlayerInput>().Player.Dash.performed -= StartDash;

        private void SetMovement(Vector2 newMovement) => movement = newMovement;
        private void StartDash(InputAction.CallbackContext context)
        {
            //some params
            float layerMaskTransitionDelay = 0.7f;

            if (movement != Vector2.zero && dashState == DashState.None)
            {
                OnDash.Invoke();
                StartCoroutine(Dashing());
            }

            IEnumerator Dashing()
            {
                dashState = DashState.NowDashing;
                int defaultLayer = gameObject.layer;
                gameObject.layer = layerIndex;

                float startTime = Time.time;
                Vector2 movementOnDash = movement *= 10;

                while (Time.time <= startTime + dashDuration)
                {
                    playerRigidbody.velocity = movementOnDash * dashSpeed;
                    yield return new WaitForFixedUpdate();
                }

                AfterDash.Invoke();

                DashCulldown();
                yield return new WaitForSeconds(layerMaskTransitionDelay);
                gameObject.layer = defaultLayer;
            }
            async void DashCulldown()
            {
                dashState = DashState.Culldown;
                await Task.Delay(dashCulldown);
                dashState = DashState.None;
            }
        }
    }
}