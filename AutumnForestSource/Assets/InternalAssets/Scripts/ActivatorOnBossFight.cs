using UnityEngine;

namespace AutumnForest.BossFight
{
    [DisallowMultipleComponent()]
    public sealed class ActivatorOnBossFight : MonoBehaviour
    {
        enum ActivateType
        {
            EnableOnStartDisableOnEnd,
            EnableOnEndDisableOnStart,
            EnableOnEnd,
            EnableOnStart,
            DisableOnStart,
            DisableOnEnd,
        }

        [SerializeField] private ActivateType type;
        [SerializeField] private bool disableOnAwake = true;

        private void Awake()
        {
            if (type == ActivateType.EnableOnStartDisableOnEnd)
            {
                GlobalServiceLocator.GetService<BossFightManager>().OnBossFightStarted += Enable;
                GlobalServiceLocator.GetService<BossFightManager>().OnBossFightEnded += Disable;
            }
            else if (type == ActivateType.EnableOnEndDisableOnStart)
            {
                GlobalServiceLocator.GetService<BossFightManager>().OnBossFightStarted += Disable;
                GlobalServiceLocator.GetService<BossFightManager>().OnBossFightEnded += Enable;
            }
            else if (type == ActivateType.EnableOnEnd)
            {
                GlobalServiceLocator.GetService<BossFightManager>().OnBossFightEnded += Enable;
            }
            else if (type == ActivateType.DisableOnEnd)
            {
                GlobalServiceLocator.GetService<BossFightManager>().OnBossFightEnded += Disable;
            }
            else if (type == ActivateType.EnableOnStart)
            {
                GlobalServiceLocator.GetService<BossFightManager>().OnBossFightStarted += Enable;
            }
            else if (type == ActivateType.DisableOnStart)
            {
                GlobalServiceLocator.GetService<BossFightManager>().OnBossFightStarted += Disable;
            }

            if (disableOnAwake) Disable();
        }

        private void Disable() => gameObject.SetActive(false);
        private void Enable() => gameObject.SetActive(true);
    }
}