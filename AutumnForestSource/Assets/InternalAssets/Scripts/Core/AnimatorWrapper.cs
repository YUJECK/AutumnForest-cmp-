using UnityEngine;

namespace AutumnForest
{
    public abstract class AnimatorWrapper
    {
        private Animator animator;
        private string currentAnimation;

        public AnimatorWrapper(Animator animator) => this.animator = animator;

        protected void Play(string animation)
        {
            if (animation == "") 
            {
                Debug.LogWarning("Animation does not implemented");
                return;
            }

            if (animation != currentAnimation)
            {
                currentAnimation = animation;
                animator.Play(currentAnimation);
            }
        }
    }
}