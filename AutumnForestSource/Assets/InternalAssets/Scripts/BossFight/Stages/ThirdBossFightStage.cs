using AutumnForest.BossFight.Raccoon;
using AutumnForest.StateMachineSystem;
using CreaturesAI.Health;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public class ThirdBossFightStage : State
    {
        //health barPresets
        [SerializeField] private HealthBarPreset raccoonPreset;
        [SerializeField] private HealthBar bossHealthBar;

        public float StateTransitionDelay { get; }

        public void EnterState(StateMachine.StateMachineSystem stateMachine)
        {
            RaccoonStateMachine raccoonStateMachine = GlobalServiceLocator.GetService<RaccoonStateMachine>();

            raccoonPreset.HealthTarget = raccoonStateMachine.GetComponent<Health>();
            bossHealthBar.SetPreset(raccoonPreset);
            raccoonStateMachine.StateChoosing();
        }

        public void ExitState(StateMachine.StateMachineSystem stateMachine) { bossHealthBar.gameObject.SetActive(false); }

        public void UpdateState(StateMachine.StateMachineSystem stateMachine) { }
    }
}