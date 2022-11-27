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
            Debug.Log("Enter shooting state");

            int random = Random.Range(0, 1);
            currentPattern = null;

            switch (random)
            {
                case 0:
                    currentPattern = Instantiate(roundShootingFirstStage);
                    break;

            }


            currentPattern.OnPatternEnd.AddListener(stateMachine.StateChoosing);
            currentPattern.UsePattern(stateMachine.Shooting);

            stateMachine.StateChoosing(); 
        }

        public override void ExitState(StateMachine stateMachine) 
        {
            currentPattern.CompletePattern(stateMachine.Shooting);
            currentPattern.OnPatternEnd.RemoveListener(stateMachine.StateChoosing);
        }

        public override void UpdateState(StateMachine stateMachine) { }
    }
}