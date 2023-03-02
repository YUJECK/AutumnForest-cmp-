using UnityEngine;

namespace AutumnForest
{
    public sealed class FoxAnimator : AnimatorWrapper
    {
        private const string Idle = "FoxIdle";
        private const string Casting = "FoxCasting";
        private const string Tired = "FoxTired";
        private const string Jump = "FoxJump";
        private const string Grounded = "FoxGrounded";

        public FoxAnimator(Animator animator) : base(animator) { }

        public void PlayIdle() => Play(Idle);
        public void PlayCasting() => Play(Casting);
        public void PlayTired() => Play(Tired);
        public void PlayJump() => Play(Jump);
        public void PlayGrounded() => Play(Grounded);
    }
}