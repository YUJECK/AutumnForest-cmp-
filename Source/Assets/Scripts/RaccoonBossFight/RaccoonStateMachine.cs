using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonStateMachine : StateMachine
    {
        [SerializeField] private State idleState;
        [SerializeField] private State[] coneThrowingState;
        [SerializeField] private State clothesThrowingState;
        [SerializeField] private State healingState;

        public override void StateChoosing()
        {
            State nextState = idleState;

            if(nextState != CurrentState)
                ChangeState(nextState);
        }

        protected override void UpdateStates()
        {
            CurrentState.UpdateState(this);
        }
    }
}