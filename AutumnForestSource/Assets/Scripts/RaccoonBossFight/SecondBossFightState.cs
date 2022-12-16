using AutumnForest.BossFight.Fox;
using AutumnForest.Other;
using CreaturesAI;
using CreaturesAI.Health;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public class SecondBossFightState : State
    {
        //health barPresets
        [SerializeField] private HealthBarPreset foxPreset;
        [SerializeField] private HealthBar bossHealthBar;

        public override void EnterState(StateMachine stateMachine)
        {
            FoxStateMachine foxStateMachine = ServiceLocator.GetService<FoxStateMachine>();
            foxPreset.HealthTarget = foxStateMachine.GetComponent<Health>();
            bossHealthBar.SetPreset(foxPreset);
            ServiceLocator.GetService<MainCameraBrain>().SetTargets(foxStateMachine.gameObject);
            foxStateMachine.gameObject.SetActive(true);
            foxStateMachine.StartStateMachine();
        }

        public override void ExitState(StateMachine stateMachine)
        {
            ServiceLocator.GetService<FoxStateMachine>().gameObject.SetActive(false);
        }

        public override void UpdateState(StateMachine stateMachine) => stateMachine.StateChoosing();
    }
}