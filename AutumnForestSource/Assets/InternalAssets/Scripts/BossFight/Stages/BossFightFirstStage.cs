using AutumnForest.BossFight.Raccoon;
using AutumnForest.Health;
using AutumnForest.StateMachineSystem;

namespace AutumnForest.BossFight.Stages
{
    public sealed class BossFightFirstStage : StateBehaviour
    {
        public override void EnterState(IStateMachineUser stateMachine)
        {
            GlobalServiceLocator.GetService<RaccoonStateMachineUser>().StateMachine.EnableStateMachine();

            GlobalServiceLocator.GetService<BossFightUIMarker>().BossFightHealthBar.SetConfig(GlobalServiceLocator.GetService<RaccoonStateMachineUser>()
                .ServiceLocator.GetService<CreatureHealth>().HealthBarConfig);

            IsCompleted = true;
        }
    }
}