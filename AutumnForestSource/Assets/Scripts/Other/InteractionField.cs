using AutumnForest.Player;
using UnityEngine;

namespace AutumnForest.Other
{
    [RequireComponent(typeof(OnTriggerExitEvent))]
    [RequireComponent(typeof(OnTriggerEnterEvent))]
    public class InteractionField : MonoBehaviour
    {
        [SerializeField] private IInteractive interactive;

        private OnTriggerEnterEvent onTriggerEnter;
        private OnTriggerExitEvent onTriggerExit;

        public OnTriggerEnterEvent OnTriggerEnter => onTriggerEnter;
        public OnTriggerExitEvent OnTriggerExit => onTriggerExit;

        private void Awake()
        {
            onTriggerEnter = GetComponent<OnTriggerEnterEvent>();
            onTriggerExit = GetComponent<OnTriggerExitEvent>();
        }
        private void Start()
        {
            if(interactive != null)
            {
                onTriggerEnter.OnEnter.AddListener(
                    delegate { ServiceLocator.GetService<PlayerInput>().AddInput(KeyCode.E, interactive.Interact, false); });
                onTriggerEnter.OnEnter.AddListener(
                    delegate { ServiceLocator.GetService<PlayerInput>().RemoveInput(KeyCode.E); });
            }
        }
    }
}