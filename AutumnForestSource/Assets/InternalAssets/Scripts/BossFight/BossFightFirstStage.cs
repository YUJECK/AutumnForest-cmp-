using AutumnForest.BossFight.Raccoon;
using AutumnForest.Managers;
using AutumnForest.StateMachineSystem;

namespace AutumnForest.BossFight
{
    public sealed class BossFightFirstStage : StateBehaviour
    {
        public override void EnterState(IStateMachineUser stateMachine)
        {
            GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToBossFightCamera();
            GlobalServiceLocator.GetService<RaccoonStateMachineUser>().StateMachine.EnableStateMachine();
        }
    }
}