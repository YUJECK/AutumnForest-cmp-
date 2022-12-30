using AutumnForest.BossFight.Fox;
using AutumnForest.BossFight.Raccoon;
using CreaturesAI;
using CreaturesAI.Health;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.BossFight
{
    public enum BossFightStages
    {
        FirstStage,
        SecondStage,
        ThirdStage,
    }

    public class BossFightController : MonoBehaviour, IStateMachineUser
    {
        [ReadOnly] private BossFightStages currentStage;
        //bossfight stages
        [SerializeField] private State firstStage;
        [SerializeField] private State secondStage;
        [SerializeField] private State thirdStage;
        //some objects
        private Health raccoonHealth;
        private Health foxHealth;
        //events
        public UnityEvent<BossFightStages> OnStageChanged = new UnityEvent<BossFightStages>();

        //getters
        public BossFightStages CurrentStage => currentStage;

        public UnityEvent<State> OnStateChanged { get; private set; } = new();

        public StateMachine StateMachine { get; private set; }

        public CreatureServiceLocator CreatureServiceLocator { get; private set; } 

        //methods
        private void OnEnable()
        {
            raccoonHealth = GlobalServiceLocator.GetService<RaccoonStateMachine>().GetComponent<Health>();    
            foxHealth = GlobalServiceLocator.GetService<FoxStateMachine>().GetComponent<Health>();
            FindObjectOfType<EnteringToBossFight>().OnInteract.AddListener( delegate { StateMachine.EnableStateMachine(); });
        }
        public void StateChoosing()
        {
            State nextStage = firstStage;

            if (raccoonHealth.CurrentHealth < 0.5 * raccoonHealth.MaximumHealth)
            {
                nextStage = secondStage;
                currentStage = BossFightStages.SecondStage;
            }
            if (foxHealth.CurrentHealth <= 0)
            {
                nextStage = thirdStage;
                currentStage = BossFightStages.ThirdStage;
            }
            if (StateMachine.CurrentState != nextStage)
                OnStageChanged.Invoke(currentStage);
        }
    }
}