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
        [SerializeField] private State waterJetState;
        [SerializeField] private State squirrelSpawnState;
        [SerializeField] private State clothesThrowingState;
        [SerializeField] private State healingState;
        [SerializeField] private State dialogueState;

        private bool isStart = true;

        private MafiaFightController fightController;

        //override methods
        public override void StateChoosing()
        {
            Debug.Log("State Choosing");

            State nextState = idleState;

            switch (fightController.CurrentStage)
            {
                case Stages.FirstStage:
                    if (Vector3.Distance(ObjectList.Player.transform.position, transform.position) > 5.5)
                        nextState = clothesThrowingState;
                    else nextState = waterJetState;


                    if(isStart)
                    {
                        nextState = dialogueState;
                        isStart = false;
                    }

                    break;
                case Stages.SecondStage:
                    break;
                case Stages.ThirdStage:
                    break;
            }

            ChangeState(nextState);
        }
        protected override void UpdateStates()
        {
            if(CurrentState != null)
                CurrentState.UpdateState(this);
        }

        //unity methods
        private void Start()
        {
            fightController = FindObjectOfType<MafiaFightController>();
        }
    }
}