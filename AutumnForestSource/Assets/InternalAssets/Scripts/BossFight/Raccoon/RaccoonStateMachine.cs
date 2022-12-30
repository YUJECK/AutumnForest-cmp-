using AutumnForest.Editor;
using CreaturesAI;
using CreaturesAI.Health;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.BossFight.Raccoon
{
    [RequireComponent(typeof(StateMachine))]
    public class RaccoonStateMachine : MonoBehaviour, IStateMachineUser
    {
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
        public UnityEvent<State> OnStateChanged { get; } = new();
        public StateMachine StateMachine { get; private set; }
        public CreatureServiceLocator CreatureServiceLocator { get; private set; }

        private void OnEnable()
        {
            GlobalServiceLocator.GetService<BossFightController>().OnStageChanged.AddListener(SetCurrentStage);
            StateMachine = GetComponent<StateMachine>();
            CreatureServiceLocator = GetComponent<CreatureServiceLocator>();
        }

        private void SetCurrentStage(BossFightStages newStage) => currentStage = newStage;
        public void StateChoosing()
        {
            State nextState = idleState;

            if (CreatureServiceLocator.GetService<Health>().CurrentHealth > 0)
            {
                if (currentStage == BossFightStages.FirstStage) nextState = FirstStageStateChoosing();
                else if (currentStage == BossFightStages.SecondStage) nextState = healingState;
                else if (currentStage == BossFightStages.ThirdStage) nextState = ThirdStageStateChoosing();
            }

            OnStateChanged.Invoke(nextState);
        }
        
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
    }
}