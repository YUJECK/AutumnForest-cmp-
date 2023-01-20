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
        public event Action OnMachineWorking;
        public event Action OnMachineDisabled;

        public StateMachineCondition MachineCondition { get; private set; } = StateMachineCondition.Stopped;
        public IStateMachineUser StateMachineUser { get; private set; }

        public StateMachine(IStateMachineUser stateMachineUser, bool enableImmediatly, params Action[] onWorking)
        {
            this.StateMachineUser = stateMachineUser;
            this.StateMachineUser.OnStateChanged += SwitchState;
            
            for (int i = 0; i < onWorking.Length; i++)
                this.OnMachineWorking += onWorking[i];

            if (enableImmediatly)
                EnableStateMachine();

            Work();
        }

        public void EnableStateMachine()
        {
            if (MachineCondition != StateMachineCondition.Working)
            {
                //StateMachineUser.StateChoosing();
                MachineCondition = StateMachineCondition.Working;
                OnMachineEnabled?.Invoke();
            }
        }
        private async void Work()
        {
            int machineWorkDelay = 1;

            while (true)
            {
                if(MachineCondition == StateMachineCondition.Working)
                {
                    OnMachineWorking?.Invoke();
                    await UniTask.Delay(machineWorkDelay);
                }
            }
        }
        public void DisableStateMachine()
        {
            CurrentState.ExitState(StateMachineUser);
            MachineCondition = StateMachineCondition.Stopped;
            OnMachineDisabled?.Invoke();
        }
        
        private void SwitchState(StateBehaviour nextState)
        {
            if (nextState != null)
            {
                if(nextState.CanEnterNewState())
                {
                    if (CurrentState != null)
                        CurrentState.ExitState(StateMachineUser);

                    CurrentState = nextState;
                    CurrentState.EnterState(StateMachineUser);
                }
            }
            else throw new NullReferenceException(nameof(nextState));
        }
    }
}