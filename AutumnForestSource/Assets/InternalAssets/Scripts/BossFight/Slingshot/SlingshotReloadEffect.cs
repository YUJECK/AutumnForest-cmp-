using System;
using UnityEngine;

namespace AutumnForest.BossFight.Slingshot
{
    [RequireComponent(typeof(Slingshot))]
    public class SlingshotReloadEffect : MonoBehaviour
    {
        [SerializeField] private GameObject effect;
        private Animator effectAnimator;
        
        private Slingshot slingshot;
        private string reloadAnimation = "Exploit";

        private void Awake()
        {
            if (effect.TryGetComponent(out Animator animator))
                effectAnimator = animator;
            else
                throw new NullReferenceException(nameof(effectAnimator));

            slingshot = GetComponent<Slingshot>();
        }

        private void OnEnable() => slingshot.OnReady += OnReload;
        private void OnDisable() => slingshot.OnReady -= OnReload;

        private void OnReload() => effectAnimator.Play(reloadAnimation);
    }
}