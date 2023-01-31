using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AutumnForest.Player
{
    [RequireComponent(typeof(PlayerMovable))]
    [RequireComponent(typeof(Rigidbody2D))]

    public sealed class PlayerDash : MonoBehaviour
    {
        private enum DashState
        {
            None,
            NowDashing,
            Culldown
        }
        [SerializeField] private float dashSpeed = 5f;
        [SerializeField] private float dashDuration = 1f;
        [SerializeField] private int dashCulldown = 1;
        [SerializeField] private int layerIndex = 10;

        [NaughtyAttributes.ReadOnly] private DashState dashState;

        public event Action OnDashed;
        public event Action OnDashReleased;
        public event Action OnCulldown;

        private PlayerMovable playerMovable;
        private Rigidbody2D playerRigidbody;
        private Vector2 dashMovement => playerMovable.Movement * dashSpeed;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerMovable = GetComponent<PlayerMovable>();
        }
        private void OnEnable()
        {
            GlobalServiceLocator.GetService<PlayerInput>().Inputs.Dash.performed += InvokeDash;

        }
        private void OnDisable()
        {
            GlobalServiceLocator.GetService<PlayerInput>().Inputs.Dash.performed -= InvokeDash;
        }

        private async void InvokeDash(InputAction.CallbackContext context)
        {
            if(dashState == DashState.None)
            {
                playerMovable.enabled = false; 

                await Dashing();

                playerMovable.enabled = true;
                
                await CullDown();
                dashState = DashState.None;
            }
        }
        private async UniTask Dashing()
        {
            OnDashed?.Invoke();
            playerRigidbody.AddForce(dashMovement, ForceMode2D.Impulse);

            await UniTask.Delay(TimeSpan.FromSeconds(dashDuration));
            OnDashReleased?.Invoke();
        }
        private async UniTask CullDown()
        {
            dashState = DashState.Culldown;
            await UniTask.Delay(TimeSpan.FromSeconds(dashCulldown));
        }
    }
}