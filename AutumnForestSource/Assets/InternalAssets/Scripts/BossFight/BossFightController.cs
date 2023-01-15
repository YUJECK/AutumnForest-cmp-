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
        [SerializeField] private State firstStage;
        [SerializeField] private State secondStage;
        [SerializeField] private State thirdStage;
        //some objects
        private Health raccoonHealth;
        private Health foxHealth;
        //events
        public UnityEvent<BossFightStages> OnBossFightStageChanged = new UnityEvent<BossFightStages>();

        //getters
        public BossFightStages CurrentBossFightStage => currentBossFightStage;
        public UnityEvent<State> OnStateChanged { get; private set; } = new();
        public StateMachine StateMachine { get; private set; }
        public CreatureServiceLocator CreatureServiceLocator { get; private set; }

        event Action<State> IStateMachineUser.OnStateChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        //methods
        private void OnEnable()
        {
            raccoonHealth = GlobalServiceLocator.GetService<RaccoonStateMachine>().GetComponent<Health>();
            foxHealth = GlobalServiceLocator.GetService<FoxStateMachine>().GetComponent<Health>();
            FindObjectOfType<EnteringToBossFight>().OnInteract.AddListener((UnityAction)delegate { StateMachine.EnableStateMachine(); });

            StateMachine = new StateMachine(this, false);
        }

        public void StateChoosing()
        {
            State nextStage = StateMachine.CurrentState;
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

            if (currentBossFightStage != nextBossFightStage)
            {
                OnStateChanged.Invoke(nextStage);
                OnBossFightStageChanged.Invoke(currentBossFightStage);
            }
        }
        public void InitServices()
        {
            throw new System.NotImplementedException();
        }

        public void StateMachineUpdate()
        {
        }

        public void Update()
        {

        }
    }
}