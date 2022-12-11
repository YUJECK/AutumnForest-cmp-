using CreaturesAI;
using NaughtyAttributes;
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
        [ReadOnly] private BossFightStages currentStage;
        //bossfight stages
        [SerializeField] private State startStage;
        [SerializeField] private State firstStage;
        [SerializeField] private State secondStage;
        [SerializeField] private State thirdStage;
        //some objects
        private Health raccoonHealth;
        private Health foxHealth;
        private bool isStart = true;
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

            if (isStart)
            {
                nextStage = startStage;
                isStart = false;
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