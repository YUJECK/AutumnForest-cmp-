using UnityEngine.Events;
using UnityEngine;

namespace AutumnForest
{
    //contracts
    [RequireComponent(typeof(OnTriggerEnterEvent))]
    [RequireComponent(typeof(OnTriggerExitEvent))]
    [RequireComponent(typeof(OnKeyDownEvent))]
    public class InteractionField : MonoBehaviour
    {
        //variables
        private OnTriggerEnterEvent onTriggerEnter;
        private OnTriggerExitEvent onTriggerExit;
        private OnKeyDownEvent onKeyDown;
        //getters
        public OnTriggerEnterEvent OnTriggerEnter => onTriggerEnter;
        public OnTriggerExitEvent OnTriggerExit => onTriggerExit;
        public OnKeyDownEvent OnKeyDown => onKeyDown;

        //unity methods
        private void Awake()
        {
            //getting components
            onTriggerEnter = GetComponent<OnTriggerEnterEvent>();
            onTriggerExit = GetComponent<OnTriggerExitEvent>();
            onKeyDown = GetComponent<OnKeyDownEvent>();
        }
        private void Start()
        {
            //adding persistent listeners
            onTriggerEnter.OnEnter.AddListener(delegate { onKeyDown.SetActive(true); });
            onTriggerExit.OnExit.AddListener(delegate { onKeyDown.SetActive(false); });
        }
    }
}