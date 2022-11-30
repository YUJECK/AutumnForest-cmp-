using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public class PlayerInput : MonoBehaviour
    {
        private Vector2 movement;
        public UnityEvent OnAttackInput = new UnityEvent();
        public UnityEvent OnDashInput = new UnityEvent();

        public Vector2 Movement => movement;

        void Update()
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            if (Input.GetMouseButtonDown(0)) OnAttackInput.Invoke();
            if (Input.GetMouseButtonDown(1)) OnDashInput.Invoke();
        }
    }
}