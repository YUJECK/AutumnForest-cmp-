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


        public void EnterState(IStateMachineUser stateMachineUser)
        {
            int random = Random.Range(0, 2);
            currentPattern = null;

            switch (random)
            {
                case 0:
                    //currentPattern = Instantiate(roundShootingFirstStage);
                    break;
                case 1:
                //    currentPattern = Instantiate(tripleShotFirstStage[Random.Range(0, tripleShotFirstStage.Length)]);
                    break;
            }

            currentPattern.OnPatternEnd.AddListener(stateMachineUser.StateChoosing);
            currentPattern.UsePattern(shooting);
        }
        public override void ExitState(IStateMachineUser stateMachineUser) 
        {
            currentPattern.CompletePattern(shooting);
            currentPattern.OnPatternEnd.RemoveListener(stateMachineUser.StateChoosing);
        }
    }
}