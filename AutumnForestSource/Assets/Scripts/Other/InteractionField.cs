using AutumnForest.Player;
using UnityEngine;

namespace AutumnForest.Other
{
    [RequireComponent(typeof(OnTriggerExitEvent))]
    [RequireComponent(typeof(OnTriggerEnterEvent))]
    public class InteractionField : InteractiveHandler
    {
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
            if(Interactive != null)
            {
                onTriggerEnter.OnEnter.AddListener(
                    delegate { ServiceLocator.GetService<PlayerInput>().AddInput(KeyCode.E, Interactive.Interact, false); });
                onTriggerExit.OnExit.AddListener(
                    delegate { ServiceLocator.GetService<PlayerInput>().RemoveInput(KeyCode.E); });
            }
        }
    }
}