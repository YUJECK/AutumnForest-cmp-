using System.Collections;
using UnityEngine;

namespace AutumnForest.Player
{
    public class PlayerDash : MonoBehaviour
    {
        [Header("Propertys")]
        [SerializeField] private float dashSpeed = 5f;
        [SerializeField] private float dashDuration = 1f;
        [SerializeField] private int layerIndex;
        private bool nowDashing = false;
        //some components
        private PlayerInput playerInput;
        private Rigidbody2D playerRigidbody;
        private Coroutine dashCoroutine;

        public bool NowDashing => nowDashing;

        //unity methods
        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerInput = FindObjectOfType<PlayerInput>();
        }

        //methods
        public void Dash()
        {
            if (playerInput.Movement != Vector2.zero)
            {
                if (dashCoroutine != null) StopCoroutine(dashCoroutine);
                dashCoroutine = StartCoroutine(DashingCoroutine());
            }
        }
        private IEnumerator DashingCoroutine()
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
            yield return new WaitForSeconds(0.7f);
            gameObject.layer = defaultLayer;
        }
    }
}