using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;

namespace AutumnForest.BossFight
{
    public sealed class FoxTimingState : StateBehaviour
    {
        private float timing;

        public FoxTimingState(float timing)
        {
            this.timing = timing;
        }

        public override bool Repeatable() => false;

        public async override void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            {
                stateMachine.ServiceLocator.GetService<FoxAnimator>().PlayIdle();
                await UniTask.Delay(TimeSpan.FromSeconds(timing));
            }
            IsCompleted = true;
        }
    }
}