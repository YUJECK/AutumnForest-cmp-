using AutumnForest.StateMachineSystem;
using CreaturesAI.Health;
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public partial class RaccoonStateMachine : MonoBehaviour, IStateMachineUser
    {
        [SerializeField] private RaccoonStateContainer raccoonStates;
        [SerializeField] private RaccoonComponents raccoonComponents;
        private BossFightStages currentStage;
        private bool isStart = true;

        public StateMachine StateMachine { get; private set; }
        public CreatureServiceLocator CreatureServiceLocator { get; private set; }

        StateMachine IStateMachineUser.StateMachine => throw new NotImplementedException();

        public event Action<State> OnStateChanged;

        private void Awake()
        {
            StateMachine = new StateMachine(this, true);
            CreatureServiceLocator = GetComponent<CreatureServiceLocator>();

            InitServices();
            GlobalServiceLocator.GetService<BossFightController>().OnBossFightStageChanged.AddListener(SetCurrentBossfightStage);
        }
        public void Update()
        {
            StateMachine.CurrentState?.UpdateState(this);
        }

        private void SetCurrentBossfightStage(BossFightStages newStage)
        {
            currentStage = newStage;
            StateChoosing();
        }
        public void StateChoosing()
        {
            State nextState = raccoonStates.IdleState;

            if (CreatureServiceLocator.GetService<Health>().CurrentHealth > 0)
            {
                if (currentStage == BossFightStages.FirstStage) nextState = FirstStageStateChoosing();
                else if (currentStage == BossFightStages.SecondStage) nextState = SecondStageStateChoosing();
                else if (currentStage == BossFightStages.ThirdStage) nextState = ThirdStageStateChoosing();
            }

            OnStateChanged?.Invoke(nextState);
        }

        private State FirstStageStateChoosing()
        {
            int randomState = UnityEngine.Random.Range(0, 2);
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
        private State SecondStageStateChoosing()
        {
            return raccoonStates.HealingState;
        }
        private State ThirdStageStateChoosing()
        {
            int randomState = UnityEngine.Random.Range(0, 2);
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