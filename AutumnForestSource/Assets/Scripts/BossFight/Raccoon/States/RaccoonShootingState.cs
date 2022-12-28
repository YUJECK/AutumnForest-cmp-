using CreaturesAI;
using CreaturesAI.CombatSkills;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public class RaccoonShootingState : State
    {
        [Header("Components")]
        [SerializeField] private Shooting shooting;
        [Header("Shooting patterns")]
        [SerializeField] private ShootingPattern[] tripleShotFirstStage;
        [SerializeField] private ShootingPattern roundShootingFirstStage;
        private ShootingPattern currentPattern;

        public override void EnterState(StateMachine stateMachine)
        {
            int random = Random.Range(0, 2);
            currentPattern = null;

            switch (random)
            {
                case 0:
                    currentPattern = Instantiate(roundShootingFirstStage);
                    break;
                case 1:
                    currentPattern = Instantiate(tripleShotFirstStage[Random.Range(0, tripleShotFirstStage.Length)]);
                    break;
            }

            currentPattern.OnPatternEnd.AddListener(stateMachine.StateChoosing);
            currentPattern.UsePattern(shooting);
        }

        public override void ExitState(StateMachine stateMachine) 
        {
            currentPattern.CompletePattern(shooting);
            currentPattern.OnPatternEnd.RemoveListener(stateMachine.StateChoosing);
        }

        public override void UpdateState(StateMachine stateMachine) { }
    }
}