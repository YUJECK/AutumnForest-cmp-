using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;

namespace AutumnForest.BossFight
{
    public sealed class TimingState : StateBehaviour
    {
        private float timing;

        public TimingState(float timing)
        {
            this.timing = timing;
        }

        public override bool Repeatable() => false;

        public async override void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            {
                stateMachine.ServiceLocator.GetService<CreatureAnimator>().SetDefault();
                await UniTask.Delay(TimeSpan.FromSeconds(timing));
            }
            IsCompleted = true;
        }
    }
}