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
            //FindObjectOfType<EnteringToBossFight>().OnInteract.AddListener( delegate { StateMachine.EnableStateMachine(); });

            StateMachine = GetComponent<StateMachine>();
        }
        private void Update() => StateChoosing();

        public void StateChoosing()
        {
            State nextStageState = firstStage;
            BossFightStages nextStage = BossFightStages.FirstStage;

            if (raccoonHealth.CurrentHealth < 0.5 * raccoonHealth.MaximumHealth)
            {
                nextStageState = secondStage;
                nextStage = BossFightStages.SecondStage;
            }
            if (foxHealth.CurrentHealth <= 0)
            {
                nextStageState = thirdStage;
                nextStage = BossFightStages.ThirdStage;
            }
            if (currentStage != nextStage)
            {
                OnStateChanged.Invoke(nextStageState);
                OnStageChanged.Invoke(currentStage);
            }
        }
        public void InitServices()
        {
            throw new System.NotImplementedException();
        }
    }
}