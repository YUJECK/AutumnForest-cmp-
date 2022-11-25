using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonStateMachine : StateMachine
    {
        [SerializeField] MafiaFightController fightController;

        [SerializeField] private State idleState;
        [SerializeField] private State[] coneThrowingState;
        [SerializeField] private State clothesThrowingState;
        [SerializeField] private State healingState;
        [SerializeField] private State dialogueState;

        private bool isStart = true;

        public override void StateChoosing()
        {
            State nextState = idleState;

            if (Vector3.Distance(ObjectList.Player.transform.position, transform.position) > 2.5)
                nextState = clothesThrowingState;
            else nextState = coneThrowingState[Random.Range(0, coneThrowingState.Length)];
            if(Health.CurrentHealth <= 100)
            {
                nextState = healingState;
                fightController.BossChangeToFox();
            }

            if(isStart)
            {
                nextState = dialogueState;
                isStart = false;
            }

            ChangeState(nextState);
        }

        protected override void UpdateStates()
        {
            if(CurrentState != null)
                CurrentState.UpdateState(this);
        }
    }
}