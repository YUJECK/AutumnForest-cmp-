using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class FirstBossFightStage : State
    {
        //health barPresets
        [SerializeField] private HealthBarPreset raccoonPreset;
        [SerializeField] private HealthBar bossHealthBar;

        public override void EnterState(StateMachine stateMachine)
        {
            ServiceLocator.GetService<RaccoonStateMachine>().StateChoosing();
            raccoonPreset.HealthTarget = ServiceLocator.GetService<RaccoonStateMachine>().GetComponent<Health>();
            bossHealthBar.SetPreset(raccoonPreset);
        }

        public override void ExitState(StateMachine stateMachine)
        {

        }

        public override void UpdateState(StateMachine stateMachine)
        {
            stateMachine.StateChoosing();
        }
    }
}