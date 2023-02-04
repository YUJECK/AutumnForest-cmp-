using System;

namespace AutumnForest
{
    public interface IDisablable
    {
        event Action OnEnabled;
        event Action OnDisabled;

        bool Enabled { get; }

        void Enable();
        void Disable();
    }
}