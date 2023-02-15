using UnityEngine;

namespace AutumnForest
{
    public class RaccoonAnimator : AnimatorWrapper
    {
        public const string Idle = "RaccoonIdle";
        public const string Throwing = "RaccoonThrowing";
        public const string Jump = "RaccoonJump";
        public const string Grounded = "RaccoonGrounded";

        public RaccoonAnimator(Animator animator) : base(animator) { }

        public void PlayIdle() => Play(Idle);
        public void PlayThrowing() => Play(Throwing);
        public void PlayJump() => Play(Jump);
        public void PlayGrounded() => Play(Grounded);
    }
}