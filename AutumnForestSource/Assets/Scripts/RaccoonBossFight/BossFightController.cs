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

    public class BossFightController : StateMachine
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
        public UnityEvent<BossFightStages> OnStageChanges = new UnityEvent<BossFightStages>();

        //getters
        public BossFightStages CurrentStage => currentStage;

        //methods
        private void Awake()
        {
            raccoonHealth = GameObject.FindGameObjectWithTag(TagHelper.RaccoonTag).GetComponent<Health>();    
            foxHealth = GameObject.FindGameObjectWithTag(TagHelper.FoxTag).GetComponent<Health>();
            FindObjectOfType<EnteringToBossFight>().OnEnter.AddListener(delegate { StartStateMachine(); });
        }
        public override void StateChoosing()
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
            
            if (CurrentState != nextStage)
            {
                OnStageChanges.Invoke(currentStage);
                ChangeState(nextStage);
            }
        }
        protected override void UpdateStates()
        {
            if (CurrentState != null)
                CurrentState.UpdateState(this);
        }
    }
}