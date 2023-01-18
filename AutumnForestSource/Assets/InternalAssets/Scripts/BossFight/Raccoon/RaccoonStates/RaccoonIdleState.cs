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
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
        }

        public override void OnFoundNextState(IStateMachineUser stateMachine, State nextState)
        {
            nextState.EnterState(stateMachine);
        }
    }
}