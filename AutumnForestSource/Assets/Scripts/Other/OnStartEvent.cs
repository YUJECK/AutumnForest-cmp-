using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public class OnStartEvent : MonoBehaviour
    {
        public UnityEvent onStart = new UnityEvent();
        void Start() => onStart.Invoke();
    }
}