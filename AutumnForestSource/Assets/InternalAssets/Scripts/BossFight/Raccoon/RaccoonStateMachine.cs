using AutumnForest.DialogueSystem;
using CreaturesAI;
using CreaturesAI.CombatSkills;
using CreaturesAI.Health;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.BossFight.Raccoon
{
    [RequireComponent(typeof(StateMachine))]
    public class RaccoonStateMachine : MonoBehaviour, IStateMachineUser
    {
        [System.Serializable]
        private class RaccoonStates
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

            public State IdleState => idleState;
            public State DialogueState => dialogueState;
            public State ShootingState => shootingState;
            public State ClothesThrowingState => clothesThrowingState;
            public State HealingState => healingState;
            public State WaterJetState => waterJetState;
            public State SquirrelSpawnState => squirrelSpawnState;
        }
        [System.Serializable] 
        private class RaccoonComponents
        {
            [SerializeField] private Shooting shooting;
            [SerializeField] private Dialogue dialogue;
            [SerializeField] private Health health;
            [SerializeField] private CreatureAnimator animator;

            public Shooting Shooting => shooting; 
            public Dialogue Dialogue => dialogue;
            public Health Health => health; 
            public CreatureAnimator Animator => animator; 
        }

        [SerializeField] private RaccoonStates raccoonStates;
        [SerializeField] private RaccoonComponents raccoonComponents;
        private BossFightStages currentStage;
        private bool isStart = true;

        public UnityEvent<State> OnStateChanged { get; } = new();
        public StateMachine StateMachine { get; private set; }
        public CreatureServiceLocator CreatureServiceLocator { get; private set; }

        private void OnEnable()
        {
            StateMachine = GetComponent<StateMachine>();
            CreatureServiceLocator = GetComponent<CreatureServiceLocator>();

            InitServices();

            GlobalServiceLocator.GetService<BossFightController>().OnStageChanged.AddListener(SetCurrentStage);
        }

        private void SetCurrentStage(BossFightStages newStage)
        {
            currentStage = newStage;
            if(currentStage != BossFightStages.FirstStage) StateChoosing();
        }
        public void StateChoosing()
        {
            State nextState = raccoonStates.IdleState;

            if (CreatureServiceLocator.GetService<Health>().CurrentHealth > 0)
            {
                if (currentStage == BossFightStages.FirstStage) nextState = FirstStageStateChoosing();
                else if (currentStage == BossFightStages.SecondStage) nextState = raccoonStates.HealingState;
                else if (currentStage == BossFightStages.ThirdStage) nextState = ThirdStageStateChoosing();
            }

            OnStateChanged.Invoke(nextState);
        }

        private State FirstStageStateChoosing()
        {
            int randomState = Random.Range(0, 2);
            State nextState = raccoonStates.IdleState;

            switch (randomState)
            {
                case 0:
                    nextState = raccoonStates.ClothesThrowingState;
                    break;
                case 1:
                    nextState = raccoonStates.ShootingState;
                    break;
            }

            if (isStart)
            {
                nextState = raccoonStates.DialogueState;
                isStart = false;
            }

            return nextState;
        }
        private State ThirdStageStateChoosing()
        {
            int randomState = Random.Range(0, 2);
            State nextState = raccoonStates.IdleState;

            switch (randomState)
            {
                case 0:
                    nextState = raccoonStates.SquirrelSpawnState;
                    break;
                case 1:
                    nextState = raccoonStates.WaterJetState;
                    break;
            }

            return nextState;
        }

        public void InitServices()
        {
            CreatureServiceLocator.RegisterService(raccoonComponents.Animator);
            CreatureServiceLocator.RegisterService(raccoonComponents.Dialogue);
            CreatureServiceLocator.RegisterService(raccoonComponents.Health);
            CreatureServiceLocator.RegisterService(raccoonComponents.Shooting);
        }
    }
}