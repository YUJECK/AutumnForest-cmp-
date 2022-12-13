using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class ThirdBossFightStage : State
    {
        //health barPresets
        [SerializeField] private HealthBarPreset raccoonPreset;
        [SerializeField] private HealthBar bossHealthBar;

        public override void EnterState(StateMachine stateMachine)
        {
            RaccoonStateMachine raccoonStateMachine = ServiceLocator.GetService<RaccoonStateMachine>();

            raccoonPreset.HealthTarget = raccoonStateMachine.GetComponent<Health>();
            ServiceLocator.GetService<Camera>().GetComponent<MainCameraBrain>().SetTarget(raccoonStateMachine.gameObject);
            bossHealthBar.SetPreset(raccoonPreset);
            raccoonStateMachine.StateChoosing();
        }

        public override void ExitState(StateMachine stateMachine) { bossHealthBar.gameObject.SetActive(false); }

        public override void UpdateState(StateMachine stateMachine) { }
    }
}