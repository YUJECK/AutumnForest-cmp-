using System;
using UnityEngine;

namespace AutumnForest
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public class CreatureAnimator : MonoBehaviour
    {
        [SerializeField] private string defaultAnimation = "Idle";
        private string currentAnimation = "";
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            SetDefault();
        }

        public void SetDefault() => PlayAnimation(defaultAnimation);
        public void PlayAnimation(string animation)
        {
            if (animation == "")
                throw new NotImplementedException(nameof(defaultAnimation));

            if (currentAnimation != animation)
                animator.Play(animation);
        }
        public void DisableAnimator()
        {
            SetDefault();
            animator.enabled = false;
        }
        public void EnableAnimator()
        {
            animator.enabled = true;
            SetDefault();
        }
    }
}