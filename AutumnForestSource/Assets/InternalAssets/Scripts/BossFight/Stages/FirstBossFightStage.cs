using AutumnForest.BossFight.Raccoon;
using AutumnForest.StateMachineSystem;
using CreaturesAI.Health;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public class FirstBossFightStage : StateBehaviour
    {
        //health barPresets
        private HealthBarPreset raccoonPreset;
        private HealthBar bossHealthBar;

        public override void EnterState(IStateMachineUser stateMachine)
        {
            GlobalServiceLocator.GetService<RaccoonStateMachine>().TryGetComponent(out Health health);
            if (health != null) raccoonPreset.HealthTarget = health;
            else Debug.LogError("Health component doesnt set to Raccoon");
            bossHealthBar.SetPreset(raccoonPreset);
            GlobalServiceLocator.GetService<RaccoonStateMachine>().StateMachine.EnableStateMachine();
        }
        public override void ExitState(IStateMachineUser stateMachine) { }
        public override void UpdateState(IStateMachineUser stateMachine) => stateMachine.StateChoosing();
    }
}