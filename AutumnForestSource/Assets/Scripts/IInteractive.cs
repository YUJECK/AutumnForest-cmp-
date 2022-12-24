using UnityEngine.Events;

namespace AutumnForest.Other
{
    public interface IInteractive
    {
        public UnityEvent OnInteract { get; set; }

        public virtual void Init() { }
        public void Interact();
    }
}