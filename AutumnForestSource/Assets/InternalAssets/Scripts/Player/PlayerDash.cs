using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
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
        [SerializeField] private int layerIndex;
        //some bollean fields
        private bool nowDashing = false;
        private bool isCulldown = false;
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
        }

        //methods
        private void SetMovement(Vector2 newMovement) => movement = newMovement;
        private void StartDash(InputAction.CallbackContext context)
        {
            //some params
            float layerMaskTransitionDelay = 0.7f;

            if (!isCulldown)
            {
                StartCoroutine(Dashing());
                DashCulldown();
            }

            IEnumerator Dashing()
            {
                nowDashing = true;
                int defaultLayer = gameObject.layer;
                gameObject.layer = layerIndex;

                float startTime = Time.time;
                Vector2 movement = context.ReadValue<Vector2>() * 10;

                while (Time.time <= startTime + dashDuration)
                {
                    playerRigidbody.velocity = movement * dashSpeed;
                    yield return new WaitForFixedUpdate();
                }

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