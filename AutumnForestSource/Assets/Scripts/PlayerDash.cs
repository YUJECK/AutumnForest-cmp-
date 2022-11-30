using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    public class PlayerDash : MonoBehaviour
    {
        [Header("Propertys")]
        [SerializeField] private float dashSpeed = 5f;
        [SerializeField] private float dashDuration = 1f;
        [SerializeField] private LayerMask dashLayer;
        private bool nowDashing = false;
        //some components
        private PlayerInput playerInput;
        private Rigidbody2D rigidbody;

        public bool NowDashing => nowDashing;

        //unity methods
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            playerInput = FindObjectOfType<PlayerInput>();
        }

        //methods
        public void Dash()
        {
            gameObject.layer = dashLayer;
            StartCoroutine(DashingCoroutine());
        }
        private IEnumerator DashingCoroutine()
        {
            nowDashing = true;

            float startTime = Time.time;
            Vector2 movement = playerInput.Movement*10;

            while (Time.time <= startTime + dashDuration)
            {
                rigidbody.velocity = movement * dashSpeed;
                yield return new WaitForFixedUpdate();
            }

            nowDashing = false;
        }
    }
}