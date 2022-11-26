using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonStateMachine : StateMachine
    {
        [SerializeField] MafiaFightController fightController;

        [SerializeField] private State idleState;
        [SerializeField] private State shootingState;
        [SerializeField] private State clothesThrowingState;
        [SerializeField] private State healingState;
        [SerializeField] private State dialogueState;

        private bool isStart = true;

        private void Start() => FindObjectOfType<MafiaFightController>().onBossFightBegins.AddListener(StateChoosing);

        public override void StateChoosing()
        {
            State nextState = idleState;

            if (Vector3.Distance(ObjectList.Player.transform.position, transform.position) > 3.5)
                nextState = clothesThrowingState;
            else nextState = shootingState;
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