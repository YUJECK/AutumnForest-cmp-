using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace AutumnForest.Player
{
    public class PlayerDash : MonoBehaviour
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
        private PlayerInput playerInput;
        private Rigidbody2D playerRigidbody;
        
        //getters
        public bool NowDashing => nowDashing;

        //unity methods
        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerInput = ServiceLocator.GetService<PlayerInput>();
            playerInput.OnRightMouseButtonPressed.AddListener(StartDash);
        }

        //methods
        private void StartDash()
        {
            //some params
            float layerMaskTransitionDelay = 0.7f;

            if (playerInput.Movement != Vector2.zero && !isCulldown)
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
                Vector2 movement = playerInput.Movement * 10;

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