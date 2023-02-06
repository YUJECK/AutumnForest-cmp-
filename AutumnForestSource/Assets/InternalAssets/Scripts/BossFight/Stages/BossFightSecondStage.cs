using AutumnForest.BossFight.Raccoon;
using AutumnForest.Health;
using AutumnForest.Helpers;
using AutumnForest.StateMachineSystem;

namespace AutumnForest.BossFight.Stages
{
    public sealed class BossFightSecondStage : StateBehaviour
    {
        public override void EnterState(IStateMachineUser stateMachine)
        {
            GlobalServiceLocator.GetService<FoxStateMachineUser>().gameObject.SetActive(true);
            
            HealthBarHelper.BossHealthBar.SetConfig(GlobalServiceLocator.GetService<FoxStateMachineUser>()
                .ServiceLocator.GetService<CreatureHealth>().HealthBarConfig);
            
            GlobalServiceLocator.GetService<FoxStateMachineUser>().StateMachine.EnableStateMachine();

            IsCompleted = true;
        }
    }
}