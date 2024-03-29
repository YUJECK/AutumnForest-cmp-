using System;
using UnityEngine;

namespace AutumnForest
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerMovable : MonoBehaviour, IDisablable
    {
        [SerializeField] private float moveSpeed = 2.5f;
        private Vector2 movement;
        new private Rigidbody2D rigidbody2D;
        private PlayerInput playerInput;

        public event Action<Vector2> OnMoved;
        public event Action<Vector2> OnMoveReleased;
        
        public event Action OnEnabled;
        public event Action OnDisabled;

        public Vector2 Movement => movement;
        public bool IsStopped { get; set; }

        public bool Enabled { get; private set; }

        private void Awake()
        {
            playerInput = GlobalServiceLocator.GetService<PlayerInput>();
            rigidbody2D = GetComponent<Rigidbody2D>();

            Enable();
        }
        private void FixedUpdate()
        {
            if(Enabled)
            {
                movement = playerInput.Inputs.Move.ReadValue<Vector2>();
                rigidbody2D.velocity = movement * moveSpeed;

                if (movement != Vector2.zero) OnMoved?.Invoke(movement);
                else OnMoveReleased?.Invoke(movement);
            }
            else
            {
                movement = Vector2.zero;
                rigidbody2D.velocity = movement;
                OnMoveReleased?.Invoke(movement);
            }
        }

        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }
    }
}