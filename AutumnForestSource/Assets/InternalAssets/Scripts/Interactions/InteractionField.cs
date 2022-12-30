using AutumnForest.Editor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AutumnForest.Other
{
    [RequireComponent(typeof(OnTriggerExitEvent))]
    [RequireComponent(typeof(OnTriggerEnterEvent))]

    public sealed class InteractionField : MonoBehaviour
    {
        [SerializeField, Interface(typeof(IInteractive))] private Object interactive;
        private IInteractive Interactive => interactive as IInteractive;

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
        private void EnterEvent() => GlobalServiceLocator.GetService<PlayerInput>().Player.Interact.started += Interact;
        private void ExitEvent() => GlobalServiceLocator.GetService<PlayerInput>().Player.Interact.started -= Interact;
        private void Interact(InputAction.CallbackContext context) => Interactive.Interact();
    }
}