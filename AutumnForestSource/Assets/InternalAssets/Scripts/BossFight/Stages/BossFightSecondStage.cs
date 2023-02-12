using AutumnForest.BossFight.Fox;
using AutumnForest.Health;
using AutumnForest.StateMachineSystem;

namespace AutumnForest.BossFight.Stages
{
    public sealed class BossFightSecondStage : StateBehaviour
    {
        public override void EnterState(IStateMachineUser stateMachine)
        {
            GlobalServiceLocator.GetService<FoxStateMachineUser>().gameObject.SetActive(true);

            GlobalServiceLocator.GetService<BossFightHealthBar>().SetConfig(GlobalServiceLocator.GetService<FoxStateMachineUser>()
                .ServiceLocator.GetService<CreatureHealth>().HealthBarConfig);

            GlobalServiceLocator.GetService<FoxStateMachineUser>().StateMachine.EnableStateMachine();

            IsCompleted = true;
        }
    }
}