using System;

namespace AutumnForest.Other
{
    public interface IInteractive
    {
        public virtual void Init() { }
        public void Interact();
    }
}