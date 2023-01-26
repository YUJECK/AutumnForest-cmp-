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
        [SerializeField] private string reloadAnimation = "Exploit";

        private void Awake()
        {
            if (effect.TryGetComponent(out Animator animator))
                effectAnimator = animator;
            else
                throw new NullReferenceException(nameof(effectAnimator));

            slingshot = GetComponent<Slingshot>();
        }

        private void OnEnable() => slingshot.OnReload += OnReload;
        private void OnDisable() => slingshot.OnReload -= OnReload;

        private void OnReload() => effectAnimator.Play(reloadAnimation);
    }
}