using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonStateMachine : StateMachine
    {
        //variables
        [Header("States")]
        [SerializeField] private State idleState;
        [SerializeField] private State shootingState;
        [SerializeField] private State clothesThrowingState;
        [SerializeField] private State healingState;
        [SerializeField] private State dialogueState;

        private bool isStart = true;

        //override methods
        public override void StateChoosing()
        {
            Debug.Log("State Choosing");

            State nextState = idleState;

            if (Vector3.Distance(ObjectList.Player.transform.position, transform.position) > 5.5)
                nextState = clothesThrowingState;
            else nextState = shootingState;
            //if(Health.CurrentHealth <= 100)
            //{
            //    nextState = healingState;
            //    fightController.BossChangeToFox();
            //}

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
        
        //unity methods
        private void Start() => FindObjectOfType<MafiaFightController>().onBossFightBegins.AddListener(StateChoosing);
    }
}