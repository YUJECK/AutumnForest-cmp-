using UnityEngine;

namespace AutumnForest.Player
{
    public sealed class PlayerAnimator : AnimatorWrapper
    {
        private const string walkAnimation = "PlayerWalk";
        private const string idleAnimation = "PlayerIdle";

        public PlayerAnimator(Animator animator) : base(animator) { }

        public void PlayIdleAnimation() => Play(idleAnimation);
        public void PlayWalkAnimation() => Play(walkAnimation);
    }
}