using UnityEditor.Events;
using UnityEngine;

namespace AutumnForest
{
    //contracts
    [RequireComponent(typeof(OnTriggerEnter))]
    [RequireComponent(typeof(OnTriggerExit))]
    [RequireComponent(typeof(OnKeyDown))]
    public class InteractionField : MonoBehaviour
    {
        //variables
        private OnTriggerEnter onTriggerEnter;
        private OnTriggerExit onTriggerExit;
        private OnKeyDown onKeyDown;
        //getters
        public OnTriggerEnter OnTriggerEnter => onTriggerEnter;
        public OnTriggerExit OnTriggerExit => onTriggerExit;
        public OnKeyDown OnKeyDown => onKeyDown;

        //unity methods
        private void Awake()
        {
            //getting components
            onTriggerEnter = GetComponent<OnTriggerEnter>();
            onTriggerExit = GetComponent<OnTriggerExit>();
            onKeyDown = GetComponent<OnKeyDown>();
        }
        private void Start()
        {
            //adding persistent listeners
            UnityEventTools.AddBoolPersistentListener(onTriggerEnter.onEnter, onKeyDown.SetActive, true);
            UnityEventTools.AddBoolPersistentListener(onTriggerExit.onExit, onKeyDown.SetActive, false);
        }
    }
}
