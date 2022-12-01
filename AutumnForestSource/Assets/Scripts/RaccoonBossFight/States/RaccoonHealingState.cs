using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonHealingState : State
    {
        [SerializeField] private Transform healingPoint;

        public override void EnterState(StateMachine stateMachine) => stateMachine.transform.position = healingPoint.position;
        public override void ExitState(StateMachine stateMachine) { }
        public override void UpdateState(StateMachine stateMachine) => stateMachine.Health.Heal(1); 
    }
}