using CreaturesAI;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public enum BossFightStages
    {
        FirstStage,
        SecondStage,
        ThirdStage,
    }

    public class BossFightController : StateMachine
    {
        private BossFightStages currentStage;
        //bossfight stages
        private State firstStage;
        private State secondStage;
        private State thirdStage;
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
        }
        public override void StateChoosing()
        {
            State nextStage = firstStage;

            if (raccoonHealth.CurrentHealth < 0.5 * raccoonHealth.MaximumHealth)
            {
                nextStage = secondStage;
                currentStage = BossFightStages.SecondStage;
            }
            else if (foxHealth.CurrentHealth <= 0)
            {
                nextStage = thirdStage;
                currentStage = BossFightStages.ThirdStage;
            }

            if (CurrentState != nextStage)
            {
                ChangeState(nextStage);
                OnStageChanges.Invoke(currentStage);
            }
        }
        protected override void UpdateStates()
        {
            if (CurrentState != null)
                CurrentState.UpdateState(this);
        }
    }
}