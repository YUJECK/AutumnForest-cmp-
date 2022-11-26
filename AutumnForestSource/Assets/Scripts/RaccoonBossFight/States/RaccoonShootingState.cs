using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonShootingState : State
    {
        [Header("First Raccoon Stage")]
        [SerializeField] private ShootingPattern[] tripleShotFirstStage;
        [SerializeField] private ShootingPattern roundShootingFirstStage;
        [Header("Second Raccoon Stage")]
        [SerializeField] private ShootingPattern[] tripleShotSecondStage;
        [SerializeField] private ShootingPattern roundShootingSecondStage;

        private ShootingPattern currentPattern;

        public override void EnterState(StateMachine stateMachine)
        {
            int random = Random.Range(0, 2);
            currentPattern = null;

            switch (random)
            {
                case 0:
                    currentPattern = roundShootingFirstStage;
                    break;
                case 1:
                    currentPattern = tripleShotFirstStage[Random.Range(0, tripleShotFirstStage.Length)];
                    break;
            }

            currentPattern.OnPatternEnd.AddListener(stateMachine.StateChoosing);
            currentPattern.UsePattern(stateMachine.Shooting);
        }

        public override void ExitState(StateMachine stateMachine) 
        {
            currentPattern.OnPatternEnd.RemoveListener(stateMachine.StateChoosing);
            currentPattern.CompletePattern(stateMachine.Shooting); 
        }

        public override void UpdateState(StateMachine stateMachine) { }
    }
}