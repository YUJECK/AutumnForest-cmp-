using AutumnForest.StateMachineSystem;

namespace AutumnForest
{
    public class RaccoonIdleState : StateBehaviour
    {
        public override bool CanExit() => true;
        public override void EnterState(IStateMachineUser stateMachine)
        {
            stateMachine.ServiceLocator.GetService<CreatureAnimator>().SetDefault();
            IsCompleted = true;
        }
    }
}