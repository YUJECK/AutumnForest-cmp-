using CreaturesAI;
using UnityEngine;

namespace AutumnForest.BossFight.Fox
{
    public class FoxStateMachine : StateMachine
    {
        [Header("States")]
        [SerializeField] private IState swordThrowingState;

        public override void StateChoosing()
        {
            IState nextState = swordThrowingState;

            ChangeState(nextState);
        }

        protected override void UpdateStates()
        {
            if (CurrentState != null)
                CurrentState.UpdateState(this);
        }
    }
}
