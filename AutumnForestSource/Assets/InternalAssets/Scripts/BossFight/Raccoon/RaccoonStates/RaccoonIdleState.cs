using AutumnForest.StateMachineSystem;

namespace AutumnForest.BossFight.Raccoon.States
{
    public sealed class RaccoonIdleState : State
    {
        public override void EnterState(IStateMachineUser stateMachine)
        {
            stateMachine.CreatureServiceLocator.GetService<CreatureAnimator>().SetDefault();
        }
        public override void UpdateState(IStateMachineUser stateMachine)
        {
            base.UpdateState(stateMachine);
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            base.ExitState(stateMachine);
        }
    }
}