using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private Vector2 movement;
        public UnityEvent OnAttackInput = new UnityEvent();
        public UnityEvent OnDashInput = new UnityEvent();
        private bool canDash = true;
        [SerializeField] private float dashCulldown = 1f;

        public Vector2 Movement => movement;

        private void Update()
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            if (Input.GetMouseButtonDown(0)) OnAttackInput.Invoke();
            if (Input.GetMouseButtonDown(1) && canDash) { OnDashInput.Invoke(); StartCoroutine(DashCulldown()); }
        }
        private IEnumerator DashCulldown()
        {
            canDash = false;
            yield return new WaitForSeconds(dashCulldown);
            canDash = true;
        }
    }
}