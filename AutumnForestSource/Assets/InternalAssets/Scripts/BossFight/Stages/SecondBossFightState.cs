using AutumnForest.BossFight.Fox;
using AutumnForest.Other;
using CreaturesAI;
using CreaturesAI.Health;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public class SecondBossFightState : MonoBehaviour, IState
    {
        public float StateTransitionDelay { get; set; }

        //health barPresets
        [SerializeField] private HealthBarPreset foxPreset;
        [SerializeField] private HealthBar bossHealthBar;

        public void EnterState(StateMachine stateMachine)
        {
            FoxStateMachine foxStateMachine = ServiceLocator.GetService<FoxStateMachine>();
            foxPreset.HealthTarget = foxStateMachine.GetComponent<Health>();
            bossHealthBar.SetPreset(foxPreset);
            ServiceLocator.GetService<MainCameraBrain>().SetTargets(foxStateMachine.gameObject);
            foxStateMachine.gameObject.SetActive(true);
            foxStateMachine.StartStateMachine();
        }

        public void ExitState(StateMachine stateMachine)
        {
            ServiceLocator.GetService<FoxStateMachine>().gameObject.SetActive(false);
        }

        public void UpdateState(StateMachine stateMachine) => stateMachine.StateChoosing();

        void IState.EnterState(StateMachine stateMachine)
        {
            throw new System.NotImplementedException();
        }

        void IState.UpdateState(StateMachine stateMachine)
        {
            throw new System.NotImplementedException();
        }

        void IState.ExitState(StateMachine stateMachine)
        {
            throw new System.NotImplementedException();
        }
    }
}