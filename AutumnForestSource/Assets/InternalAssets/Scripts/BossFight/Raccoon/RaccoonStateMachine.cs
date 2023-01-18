using AutumnForest.StateMachineSystem;
using CreaturesAI.Health;
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    [RequireComponent(typeof(CreatureServiceLocator))]
    public partial class RaccoonStateMachine : MonoBehaviour, IStateMachineUser
    {
        private RaccoonStateContainer stateContainer;
        private IStateVariation stateVariation;
        [SerializeField] private RaccoonComponents raccoonComponents;
        private BossFightStages currentStage;
        private bool isStart = true;

        public event Action<StateBehaviour> OnStateChanged;

        public StateMachine StateMachine { get; private set; }
        public CreatureServiceLocator ServiceLocator { get; private set; }


        private void Awake()
        {
            stateVariation = GetComponent<IStateVariation>();

            ServiceLocator = GetComponent<CreatureServiceLocator>();
            raccoonComponents.RegisterComponents(ServiceLocator);
            stateContainer = stateVariation.InitStates() as RaccoonStateContainer;
            GlobalServiceLocator.GetService<BossFightController>().OnBossFightStageChanged.AddListener(SetCurrentBossfightStage);
            
            StateMachine = new StateMachine(this, true);
        }

        private void SetCurrentBossfightStage(BossFightStages newStage)
        {
            currentStage = newStage;
            StateChoosing();
        }
        public void StateChoosing()
        {
            StateBehaviour nextState = stateContainer.IdleState;

            if (ServiceLocator.GetService<Health>().CurrentHealth > 0)
            {
                if (currentStage == BossFightStages.FirstStage) nextState = FirstStageStateChoosing();
                else if (currentStage == BossFightStages.SecondStage) nextState = SecondStageStateChoosing();
                else if (currentStage == BossFightStages.ThirdStage) nextState = ThirdStageStateChoosing();
            }

            OnStateChanged?.Invoke(nextState);
        }

        private StateBehaviour FirstStageStateChoosing()
        {
            if (isStart)
            {
                isStart = false;
                return stateContainer.DialogueState;
            }

            int randomState = UnityEngine.Random.Range(0, 2);
            return randomState switch
            {
                0 => stateContainer.ClothesThrowingState,
                1 => stateContainer.ShootingState,
                _ => stateContainer.IdleState
            };
        }
        private StateBehaviour SecondStageStateChoosing() => stateContainer.HealingState;
        private StateBehaviour ThirdStageStateChoosing()
        {
            int randomState = UnityEngine.Random.Range(0, 2);
            return randomState switch
            {
                0 => stateContainer.SquirrelSpawnState,
                1 => stateContainer.WaterJetState,
                _ => stateContainer.IdleState
            };
        }
    }
}