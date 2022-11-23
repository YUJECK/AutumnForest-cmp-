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
        [SerializeField] private State dialogueState;

        private bool isStart = true;

        public override void StateChoosing()
        {
            State nextState = idleState;

            if (Vector3.Distance(GameManager.Player.transform.position, transform.position) > 5)
                nextState = clothesThrowingState;
            else nextState = coneThrowingState[Random.Range(0, coneThrowingState.Length)];

            if(isStart)
            {
                nextState = dialogueState;
                isStart = false;
            }

            if(nextState != CurrentState)
                ChangeState(nextState);
        }

        protected override void UpdateStates()
        {
            if(CurrentState != null)
                CurrentState.UpdateState(this);
        }
    }
}