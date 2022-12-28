using AutumnForest.BossFight.Raccoon;
using CreaturesAI;
using CreaturesAI.Health;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public class FirstBossFightStage : MonoBehaviour, IState
    {
        //health barPresets
        [SerializeField] private HealthBarPreset raccoonPreset;
        [SerializeField] private HealthBar bossHealthBar;

        public float StateTransitionDelay { get; }

        public void EnterState(StateMachine stateMachine)
        {
            ServiceLocator.GetService<RaccoonStateMachine>().TryGetComponent(out Health health);
            if (health != null) raccoonPreset.HealthTarget = health;
            else Debug.LogError("Health component doesnt set to Raccoon");
            bossHealthBar.SetPreset(raccoonPreset);
            ServiceLocator.GetService<RaccoonStateMachine>().StartStateMachine();
        }
        public void ExitState(StateMachine stateMachine) { }
        public void UpdateState(StateMachine stateMachine) => stateMachine.StateChoosing();
    }
}