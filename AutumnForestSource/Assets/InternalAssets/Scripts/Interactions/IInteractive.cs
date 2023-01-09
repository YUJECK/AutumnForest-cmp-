using System;

namespace AutumnForest.Other
{
    public interface IInteractive
    {
        public event Action OnInteract;

        public virtual void Init() { }
        public void Interact();
    }
}