using System;
using UnityEngine;

namespace AutumnForest
{
    public abstract class UIWindow : MonoBehaviour
    {
        public bool CurrentlyActive { get; private set; }

        public event Action OnWindowEnabled;
        public event Action OnWindowDisabled;

        public void EnableWindow()
        {
            CurrentlyActive = true;

            OnWindowEnabled?.Invoke();
            SelfEnable();
        }
        protected abstract void SelfEnable();

        public void DisableWindow()
        {
            CurrentlyActive = false;

            OnWindowDisabled?.Invoke();
            SelfDisable();
        }
        protected abstract void SelfDisable();
    }
}