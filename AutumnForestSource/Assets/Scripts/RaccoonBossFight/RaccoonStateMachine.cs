using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonStateMachine : StateMachine
    {
        //variables
        [SerializeField] private Health health;
        [Header("States")]
        [SerializeField] private State idleState;
        [Header("First Stage States")]
        [SerializeField] private State dialogueState;
        [SerializeField] private State shootingState;
        [SerializeField] private State clothesThrowingState;
        [Header("Second Stage States")]
        [SerializeField] private State healingState;
        [Header("Third Stage States")]
        [SerializeField] private State waterJetState;
        [SerializeField] private State squirrelSpawnState;

        private bool isStart = true;
        private BossFightStages currentStage;

        private void SetCurrentStage(BossFightStages newStage) => currentStage = newStage;
        
        //override methods
        public override void StateChoosing()
        {
            State nextState = idleState;

            if (health.CurrentHealth > 0)
            {
                if (currentStage == BossFightStages.FirstStage) nextState = FirstStageStateChoosing();
                else if (currentStage == BossFightStages.FirstStage) nextState = healingState;
                else if (currentStage == BossFightStages.ThirdStage) nextState = ThirdStageStateChoosing();

                ChangeState(nextState);
            }
            else CurrentState.ExitState(this);

        }
        protected override void UpdateStates()
        {
            if(CurrentState != null)
                CurrentState.UpdateState(this);
        }
        //stages
        private State FirstStageStateChoosing()
        {
            int randomState = Random.Range(0, 2);
            State nextState = idleState;

            switch (randomState)
            {
                case 0:
                    nextState = clothesThrowingState;
                    break;
                case 1:
                    nextState = shootingState;
                    break;
            }

            if (isStart)
            {
                nextState = dialogueState;
                isStart = false;
            }

            return nextState;
        }
        private State ThirdStageStateChoosing()
        {
            int randomState = Random.Range(0, 2);
            State nextState = idleState;

            switch (randomState)
            {
                case 0:
                    nextState = squirrelSpawnState;
                    break;
                case 1:
                    nextState = waterJetState;
                    break;
            }

            return nextState;
        }

        //unity methods
        private void Awake() => FindObjectOfType<BossFightController>().OnStageChanges.AddListener(SetCurrentStage);
    }
}