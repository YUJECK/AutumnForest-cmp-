using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace AutumnForest.Player
{
    [RequireComponent(typeof(PlayerMove))]
    public sealed class PlayerDash : MonoBehaviour
    {
        [Header("Propertys")]
        //dash params
        [SerializeField] private float dashSpeed = 5f;
        [SerializeField] private float dashDuration = 1f;
        [SerializeField] private int dashCulldown = 1000;
        [SerializeField] private int layerIndex = 10;
        //some bollean fields
        private bool nowDashing = false;
        private bool isCulldown = false;
        //events
        private UnityEvent OnDash = new();
        private UnityEvent AfterDash = new();
        //some components
        private Rigidbody2D playerRigidbody;
        private Vector2 movement;
        //getters
        public bool NowDashing => nowDashing;

        //unity methods
        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            GetComponent<PlayerMove>().OnMove.AddListener(SetMovement);
            OnDash.AddListener(delegate { GetComponent<PlayerMove>().IsStopped = true; });
            AfterDash.AddListener(delegate { GetComponent<PlayerMove>().IsStopped = false; });
            ServiceLocator.GetService<PlayerInput>().Player.Dash.performed += StartDash;
        }

        //methods
        private void SetMovement(Vector2 newMovement) => movement = newMovement;
        private void StartDash(InputAction.CallbackContext context)
        {
            //some params
            float layerMaskTransitionDelay = 0.7f;

            if (movement != Vector2.zero && !isCulldown)
            {
                OnDash.Invoke();
                StartCoroutine(Dashing());
                DashCulldown();
            }

            IEnumerator Dashing()
            {
                nowDashing = true;
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
                
                nowDashing = false;
                yield return new WaitForSeconds(layerMaskTransitionDelay);
                gameObject.layer = defaultLayer;
            }
            async void DashCulldown()
            {
                isCulldown = true;
                await Task.Delay(dashCulldown);
                isCulldown = false;
            }
        }
    }
}