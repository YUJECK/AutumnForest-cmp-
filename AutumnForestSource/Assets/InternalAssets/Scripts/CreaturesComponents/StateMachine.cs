using NaughtyAttributes;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace CreaturesAI
{
    public enum StateMachineCondition
    {
        Working,
        Stopped
    }
    abstract public class StateMachine : MonoBehaviour
    {
        [Header("Some info")]
        private IState currentState;
        private StateMachineCondition stateMachineState = StateMachineCondition.Stopped;

        public UnityEvent OnMachineStarts = new();
        public UnityEvent OnMachineStops = new();

        public IState CurrentState => currentState;
        public StateMachineCondition StateMachineState => stateMachineState;

        protected async void ChangeState(IState newState)
        {
            if (newState != null)
            {
                if (currentState != null) currentState.ExitState(this);
                int waitTime = (int)(currentState.StateTransitionDelay * 1000);
                currentState = null;

                await Task.Delay(waitTime);

                currentState = newState;
                currentState.EnterState(this);
            }
            else Debug.LogError("New State is null");
        }

        virtual public void StartStateMachine()
        {
            if (stateMachineState != StateMachineCondition.Working)
            {
                StateChoosing();
                stateMachineState = StateMachineCondition.Working;
                OnMachineStarts.Invoke();
            }
        }
        virtual public void StopStateMachine()
        {
            currentState.ExitState(this);
            stateMachineState = StateMachineCondition.Stopped;
            OnMachineStops.Invoke();
        }

        abstract public void StateChoosing();
        abstract protected void UpdateStates();

        private void Update() => UpdateStates();
    }
}