using System;
using UnityEngine;

namespace AutumnForest.BossFight
{
    [DisallowMultipleComponent()]
    public sealed class ActivatorOnBossFight : MonoBehaviour
    {
        enum ActivateType
        {
            EnableOnStartDisableOnEnd,
            DisableOnStartEnableOnEnd,
            EnableOnEnd,
            EnableOnStart,
            DisableOnStart,
            DisableOnEnd,
        }

        [SerializeField] private ActivateType type;
        [SerializeField] private bool disableOnAwake = true;

        private void Awake()
        {
            switch (type)
            {
                case ActivateType.EnableOnStartDisableOnEnd:
                    SetEvents(Enable, Disable);
                    break;
                case ActivateType.DisableOnStartEnableOnEnd:
                    SetEvents(Disable, Enable);
                    break;
                case ActivateType.EnableOnStart:
                    SetEvents(Enable, null);
                    break;
                case ActivateType.DisableOnStart:
                    SetEvents(Disable, null);
                    break;
                case ActivateType.EnableOnEnd:
                    SetEvents(null, Enable);
                    break;
                case ActivateType.DisableOnEnd:
                    SetEvents(null, Disable);
                    break;
            }

            if (disableOnAwake) Disable();
        }

        private void SetEvents(Action onStarted, Action onEnded)
        {
            if (onStarted != null) GlobalServiceLocator.GetService<BossFightManager>().OnBossFightStarted += onStarted;
            if (onEnded != null) GlobalServiceLocator.GetService<BossFightManager>().OnBossFightEnded += onEnded;
        }

        private void Disable() => gameObject.SetActive(false);
        private void Enable() => gameObject.SetActive(true);
    }
}