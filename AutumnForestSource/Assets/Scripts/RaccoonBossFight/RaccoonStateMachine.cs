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

        private BossFightController fightController;

        //override methods
        public override void StateChoosing()
        {
            State nextState = idleState;

            if (health.CurrentHealth > 0)
            {
                if (fightController.CurrentStage == Stages.FirstStage)
                {
                    int randomState = Random.Range(0, 2);

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
                }
                else if (fightController.CurrentStage == Stages.SecondStage)
                    nextState = healingState;
                else if (fightController.CurrentStage == Stages.ThirdStage)
                {
                    int randomState = Random.Range(0, 2);

                    switch (randomState)
                    {
                        case 0:
                            nextState = squirrelSpawnState;
                            break;
                        case 1:
                            nextState = waterJetState;
                            break;
                    }
                }
                
                ChangeState(nextState);
            }
            else CurrentState.ExitState(this);

        }
        protected override void UpdateStates()
        {
            if(CurrentState != null)
                CurrentState.UpdateState(this);
        }

        //unity methods
        private void Start() => fightController = FindObjectOfType<BossFightController>();
    }
}