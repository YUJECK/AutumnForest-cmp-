using UnityEngine.Events;

namespace AutumnForest.Other
{
    internal interface IInteractive
    {
        public UnityEvent onInteract { get; set; }
        public void Interact();
    }
}