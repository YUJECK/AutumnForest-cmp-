using AutumnForest.Editor;
using CreaturesAI;
using CreaturesAI.Health;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public class RaccoonStateMachine : StateMachine
    {
        //variables
        [SerializeField] private Health health;
        [Header("States")]
        [Interface(typeof(IState)), SerializeField] private IState idleState;
        [Header("First Stage States")]
        [Interface(typeof(IState)), SerializeField] private IState dialogueState;
        [Interface(typeof(IState)), SerializeField] private IState shootingState;
        [Interface(typeof(IState)), SerializeField] private IState clothesThrowingState;
        [Header("Second Stage States")]
        [Interface(typeof(IState)), SerializeField] private IState healingState;
        [Header("Third Stage States")]
        [Interface(typeof(IState)), SerializeField] private IState waterJetState;
        [Interface(typeof(IState)), SerializeField] private IState squirrelSpawnState;

        private bool isStart = true;
        private BossFightStages currentStage;

        private void SetCurrentStage(BossFightStages newStage) => currentStage = newStage;
        
        //override methods
        public override void StateChoosing()
        {
            IState nextState = idleState;

            if (health.CurrentHealth > 0)
            {
                if (currentStage == BossFightStages.FirstStage) nextState = FirstStageStateChoosing();
                else if (currentStage == BossFightStages.SecondStage) nextState = healingState;
                else if (currentStage == BossFightStages.ThirdStage) nextState = ThirdStageStateChoosing();

                if(nextState != null) ChangeState(nextState);
            }
            else CurrentState.ExitState(this);

            Debug.Log("StateChoosing");
        }
        protected override void UpdateStates()
        {
            if(CurrentState != null)
                CurrentState.UpdateState(this);
        }
        //stages
        private IState FirstStageStateChoosing()
        {
            int randomState = Random.Range(0, 2);
            IState nextState = idleState;

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
        private IState ThirdStageStateChoosing()
        {
            int randomState = Random.Range(0, 2);
            IState nextState = idleState;

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