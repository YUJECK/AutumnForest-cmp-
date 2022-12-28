using UnityEngine;
using UnityEngine.InputSystem;

namespace AutumnForest.Other
{
    [RequireComponent(typeof(OnTriggerExitEvent))]
    [RequireComponent(typeof(OnTriggerEnterEvent))]
    public sealed class InteractionField : InteractiveHandler
    {
        private OnTriggerEnterEvent onTriggerEnter;
        private OnTriggerExitEvent onTriggerExit;

        public OnTriggerEnterEvent OnTriggerEnter => onTriggerEnter;
        public OnTriggerExitEvent OnTriggerExit => onTriggerExit;

        private void OnEnable()
        {
            onTriggerEnter = GetComponent<OnTriggerEnterEvent>();
            onTriggerExit = GetComponent<OnTriggerExitEvent>();

            if (Interactive != null)
            {
                onTriggerEnter.OnEnter.AddListener(delegate { EnterEvent(); });
                onTriggerExit.OnExit.AddListener(delegate { ExitEvent(); });
            }
        }
        private void EnterEvent() => ServiceLocator.GetService<PlayerInput>().Player.Interact.started += Interact;
        private void ExitEvent() => ServiceLocator.GetService<PlayerInput>().Player.Interact.started -= Interact;
        private void Interact(InputAction.CallbackContext context) => Interactive.Interact();
    }
}