using AutumnForest.Helpers;
using Cysharp.Threading.Tasks;
using System;

namespace AutumnForest.StateMachineSystem
{
    public enum StateMachineCondition
    {
        Working,
        Stopped
    }

    public class StateMachine : ICreatureComponent
    {
        public event Action OnMachineEnabled;
        public event Action OnMachineDisabled;

        public State CurrentState { get; private set; }
        public StateMachineCondition StateMachineState { get; private set; } = StateMachineCondition.Stopped;

        private IStateMachineUser stateMachineUser;

        public StateMachine(IStateMachineUser stateMachineUser, bool enableImmediatly)
        {
            this.stateMachineUser = stateMachineUser;
            this.stateMachineUser.OnStateChanged += ChangeState;

            if (enableImmediatly)
                EnableStateMachine();
        }

        private async void ChangeState(State newState)
        {
            if (newState != null)
            {
                if (CurrentState != null)
                {
                    CurrentState.ExitState(stateMachineUser);
                    CurrentState = null;

                    await UniTask.Delay(TimeSpan.FromSeconds(CurrentState.StateTransitionDelay));
                }

                CurrentState = newState;
                CurrentState.EnterState(stateMachineUser);
            }
            else throw new NullReferenceException(nameof(newState));
        }

        public void EnableStateMachine()
        {
            if (StateMachineState != StateMachineCondition.Working)
            {
                stateMachineUser.StateChoosing();
                StateMachineState = StateMachineCondition.Working;
                OnMachineEnabled.Invoke();
            }
        }
        public void DisableStateMachine()
        {
            CurrentState.ExitState(stateMachineUser);
            StateMachineState = StateMachineCondition.Stopped;
            OnMachineDisabled.Invoke();
        }
    }
}