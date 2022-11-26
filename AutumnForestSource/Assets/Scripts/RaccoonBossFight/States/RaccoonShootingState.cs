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

        public override void EnterState(StateMachine stateMachine)
        {

        }

        public override void ExitState(StateMachine stateMachine)
        {
        }

        public override void UpdateState(StateMachine stateMachine)
        {
        }
    }
}