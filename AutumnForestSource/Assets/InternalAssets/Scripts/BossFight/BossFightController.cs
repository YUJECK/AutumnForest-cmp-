using AutumnForest.BossFight.Fox;
using AutumnForest.BossFight.Raccoon;
using AutumnForest.StateMachineSystem;
using CreaturesAI.Health;
using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.BossFight
{
    public enum BossFightStages
    {
        None,
        FirstStage,
        SecondStage,
        ThirdStage,
    }

    public class BossFightController : MonoBehaviour, IStateMachineUser
    {
        [ReadOnly] private BossFightStages currentBossFightStage;
        //bossfight stages
        [SerializeField] private StateBehaviour firstStage;
        [SerializeField] private StateBehaviour secondStage;
        [SerializeField] private StateBehaviour thirdStage;
        //some objects
        private Health raccoonHealth;
        private Health foxHealth;
        //events
        public UnityEvent<BossFightStages> OnBossFightStageChanged = new UnityEvent<BossFightStages>();

        //getters
        public BossFightStages CurrentBossFightStage => currentBossFightStage;
        public StateMachine StateMachine { get; private set; }
        public CreatureServiceLocator ServiceLocator { get; private set; }

        public event Action<StateBehaviour> OnStateChanged;

        //methods
        private void Awake()
        {
            raccoonHealth = GlobalServiceLocator.GetService<RaccoonStateMachine>().GetComponent<Health>();
            foxHealth = GlobalServiceLocator.GetService<FoxStateMachine>().GetComponent<Health>();

            StateMachine = new StateMachine(this, false);
        }

        public void StateChoosing()
        {
            StateBehaviour nextStage = null;
            BossFightStages nextBossFightStage = currentBossFightStage;

            if (currentBossFightStage == BossFightStages.None)
            {
                nextStage = firstStage;
                nextBossFightStage = BossFightStages.FirstStage;
            }
            if (raccoonHealth.CurrentHealth < 0.5 * raccoonHealth.MaximumHealth)
            {
                nextStage = secondStage;
                nextBossFightStage = BossFightStages.SecondStage;
            }
            if (foxHealth.CurrentHealth <= 0)
            {
                nextStage = thirdStage;
                nextBossFightStage = BossFightStages.ThirdStage;
            }

            if (nextBossFightStage != null && currentBossFightStage != nextBossFightStage)
            {
                OnStateChanged.Invoke(nextStage);
                OnBossFightStageChanged.Invoke(currentBossFightStage);
            }
        }
    }
}