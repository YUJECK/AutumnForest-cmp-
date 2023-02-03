using AutumnForest.StateMachineSystem;

namespace AutumnForest.BossFight.Stages
{
    public sealed class BossFightSecondStage : StateBehaviour
    {
        public override void EnterState(IStateMachineUser stateMachine)
        {
            GlobalServiceLocator.GetService<FoxStateMachineUser>().gameObject.SetActive(true);
            GlobalServiceLocator.GetService<FoxStateMachineUser>().StateMachine.EnableStateMachine();

            IsCompleted = true;
        }
    }
}