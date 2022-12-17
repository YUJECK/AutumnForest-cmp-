using AutumnForest.BossFight.Raccoon;
using AutumnForest.Other;
using CreaturesAI;
using CreaturesAI.Health;
using UnityEngine;

namespace AutumnForest.BossFight
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
            ServiceLocator.GetService<MainCameraBrain>().SetTargets(raccoonStateMachine.gameObject);
            bossHealthBar.SetPreset(raccoonPreset);
            raccoonStateMachine.StateChoosing();
        }

        public override void ExitState(StateMachine stateMachine) { bossHealthBar.gameObject.SetActive(false); }

        public override void UpdateState(StateMachine stateMachine) { }
    }
}