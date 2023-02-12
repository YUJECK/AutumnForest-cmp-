using AutumnForest.BossFight.Fox;
using AutumnForest.BossFight.Raccoon;
using AutumnForest.BossFight.Stages;
using AutumnForest.Health;
using AutumnForest.StateMachineSystem;
using System;

namespace AutumnForest.BossFight
{
    public enum BossFightStage
    {
        NotStarted,
        First,
        Second,
        Third
    }

    public class BossFightManager : IStateMachineUser
    {
        private BossFightStage currentStage;
        public BossFightStage CurrentStage
        {
            get => currentStage;
            private set
            {
                currentStage = value;
                OnStageChanged?.Invoke(currentStage);
            }
        }

        public StateMachine StateMachine { get; private set; }
        public LocalServiceLocator ServiceLocator { get; private set; }

        public event Action<StateBehaviour> OnStateChanged;
        public event Action<BossFightStage> OnStageChanged;

        public event Action OnBossFightStarted;
        public event Action OnBossFightEnded;

        private StateBehaviour firstStage = new BossFightFirstStage();
        private StateBehaviour secondStage = new BossFightSecondStage();
        private StateBehaviour thirdStage = new BossFightFirstStage();

        private IHealth raccoonHealth;
        private IHealth foxHealth;

        public BossFightManager()
        {
            StateMachine = new(this, false);

            OnBossFightStarted += StateMachine.EnableStateMachine;
            StateMachine.OnMachineWorking += StateChoosing;

            GlobalServiceLocator.GetService<RaccoonStateMachineUser>().OnEnteredHealingState += OnEnteredHealingState;
        }

        private void OnEnteredHealingState()
        {
            OnStateChanged?.Invoke(secondStage);
        }

        private void StateChoosing()
        {
            if (CurrentStage == BossFightStage.First && raccoonHealth.CurrentHealth <= raccoonHealth.MaximumHealth * 0.7)
                CurrentStage = BossFightStage.Second;

            else if (CurrentStage == BossFightStage.Second && foxHealth.CurrentHealth <= 0)
            {
                OnStateChanged?.Invoke(thirdStage);
                CurrentStage = BossFightStage.Third;
            }
        }

        public void StartBossFight()
        {
            foxHealth = GlobalServiceLocator.GetService<FoxStateMachineUser>().ServiceLocator.GetService<CreatureHealth>();
            raccoonHealth = GlobalServiceLocator.GetService<RaccoonStateMachineUser>().ServiceLocator.GetService<CreatureHealth>();
            GlobalServiceLocator.GetService<BossFightHealthBar>().gameObject.SetActive(true);

            CurrentStage = BossFightStage.First;
            OnStateChanged?.Invoke(firstStage);

            OnBossFightStarted?.Invoke();
        }
        public void EndBossFight() => OnBossFightEnded?.Invoke();
    }
}