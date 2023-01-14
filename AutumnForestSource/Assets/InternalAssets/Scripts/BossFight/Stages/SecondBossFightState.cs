using AutumnForest.BossFight.Fox;
using AutumnForest.BossFight.Raccoon;
using AutumnForest.Other;
using CreaturesAI;
using CreaturesAI.Health;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public sealed class SecondBossFightState : State
    {
        //health barPresets
        [SerializeField] private HealthBarPreset foxPreset;
        [SerializeField] private HealthBar bossHealthBar;

        public override void EnterState(IStateMachineUser stateMachine)
        {
            FoxStateMachine foxStateMachine = GlobalServiceLocator.GetService<FoxStateMachine>();
            foxPreset.HealthTarget = foxStateMachine.GetComponent<Health>();
            bossHealthBar.SetPreset(foxPreset);
            foxStateMachine.gameObject.SetActive(true);
            GlobalServiceLocator.GetService<RaccoonStateMachine>().StateMachine.DisableStateMachine();
            foxStateMachine.StateMachine.EnableStateMachine();
        }

        public override void ExitState(IStateMachineUser stateMachine)
        {
            GlobalServiceLocator.GetService<FoxStateMachine>().gameObject.SetActive(false);
        }
    }
}