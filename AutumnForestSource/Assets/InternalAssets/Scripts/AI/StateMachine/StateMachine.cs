using Cysharp.Threading.Tasks;
using System;

namespace AutumnForest.StateMachineSystem
{
    public class StateMachine
    {
        private StateBehaviour CurrentState;

        public event Action OnMachineEnabled;
        public event Action OnMachineWorking;
        public event Action OnMachineDisabled;

        public bool Enabled { get; private set; } = false;
        public IStateMachineUser StateMachineUser { get; private set; }

        public StateMachine(IStateMachineUser stateMachineUser, bool enableImmediatly)
        {
            this.StateMachineUser = stateMachineUser;
            this.StateMachineUser.OnStateChanged += SwitchState;

            if (enableImmediatly)
                EnableStateMachine();

            Work();
        }

        public void EnableStateMachine()
        {
            if (!Enabled)
            {
                Enabled = true;
                OnMachineEnabled?.Invoke();
            }
        }
        private async void Work()
        {
            int machineWorkDelay = 1;

            while (true)
            {
                if (Enabled)
                {
                    OnMachineWorking?.Invoke();
                    CurrentState?.UpdateState(StateMachineUser);
                }
                await UniTask.Delay(machineWorkDelay);
            }
        }
        public void DisableStateMachine()
        {
            CurrentState.ExitState(StateMachineUser);
            Enabled = false;
            OnMachineDisabled?.Invoke();
        }

        private void SwitchState(StateBehaviour nextState)
        {
            if (nextState != null)
            {
                if (CurrentState != null)
                {
                    if (CurrentState == nextState && !CurrentState.Repeatable()) return;
                    if (!CurrentState.CanEnterNewState()) return;

                    CurrentState.ExitState(StateMachineUser);
                    Switch();
                }
                else Switch();
            }
            else throw new NullReferenceException(nameof(nextState));

            void Switch()
            {
                CurrentState = nextState;
                CurrentState.EnterState(StateMachineUser);
            }
        }
    }
}