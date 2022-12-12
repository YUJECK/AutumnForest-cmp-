using CreaturesAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest
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
            foxStateMachine.gameObject.SetActive(true);
            foxStateMachine.StateChoosing();
        }

        public override void ExitState(StateMachine stateMachine)
        {
            ServiceLocator.GetService<FoxStateMachine>().gameObject.SetActive(false);
        }

        public override void UpdateState(StateMachine stateMachine)
        {
        }
    }
}