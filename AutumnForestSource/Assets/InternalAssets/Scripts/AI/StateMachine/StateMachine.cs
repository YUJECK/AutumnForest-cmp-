using Cysharp.Threading.Tasks;
using System;

namespace AutumnForest.StateMachineSystem
{
    public enum StateMachineCondition
    {
        Working,
        Stopped
    }

    public class StateMachine
    {
        private StateBehaviour CurrentState;

        public event Action OnMachineEnabled;
        public event Action OnMachineDisabled;

        public StateMachineCondition StateMachineState { get; private set; } = StateMachineCondition.Stopped;
        public IStateMachineUser StateMachineUser { get; private set; }

        public StateMachine(IStateMachineUser stateMachineUser, bool enableImmediatly)
        {
            this.StateMachineUser = stateMachineUser;
            this.StateMachineUser.OnStateChanged += SwitchState;

            if (enableImmediatly)
                EnableStateMachine();
        }

        public void EnableStateMachine()
        {
            if (StateMachineState != StateMachineCondition.Working)
            {
                StateMachineUser.StateChoosing();
                StateMachineState = StateMachineCondition.Working;
                OnMachineEnabled?.Invoke();
            }
        }
        public void DisableStateMachine()
        {
            CurrentState.ExitState(StateMachineUser);
            StateMachineState = StateMachineCondition.Stopped;
            OnMachineDisabled?.Invoke();
        }
        
        private async void SwitchState(StateBehaviour nextState)
        {
            if (nextState != null)
            {
                if(nextState.CanEnterNewState())
                {
                    if (CurrentState != null)
                    {
                        CurrentState.ExitState(StateMachineUser);
                        CurrentState = null;

                        await UniTask.Delay(TimeSpan.FromSeconds(CurrentState.StateTransitionDelay));
                    }

                    CurrentState = nextState;
                    CurrentState.EnterState(StateMachineUser);
                }
            }
            else throw new NullReferenceException(nameof(nextState));
        }
    }
}