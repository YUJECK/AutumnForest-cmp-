using NaughtyAttributes;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace CreaturesAI
{
    public enum StateMachineState
    {
        Working,
        Stopped
    }

    abstract public class StateMachine : MonoBehaviour
    {
        [Header("Some info")]
        private State currentState;
        [ReadOnly, SerializeField] private string currentStateName = "None";
        private StateMachineState stateMachineState = StateMachineState.Stopped;

        public UnityEvent OnMachineStarts = new();
        public UnityEvent OnMachineStops = new();

        public State CurrentState => currentState;
        public StateMachineState StateMachineState => stateMachineState;

        protected async void ChangeState(State newState)
        {
            if (newState != null)
            {
                if (currentState != null) currentState.ExitState(this);
                int waitTime = (int)(currentState.StateTransitionDelay * 1000);
                currentState = null;

                await Task.Delay(waitTime);

                currentState = newState;
                currentStateName = currentState.StateName;
                currentState.EnterState(this);
            }
            else Debug.LogError("New State is null");
        }

        virtual public void StartStateMachine()
        {
            if (stateMachineState != StateMachineState.Working)
            {
                StateChoosing();
                stateMachineState = StateMachineState.Working;
                OnMachineStarts.Invoke();
            }
        }
        virtual public void StopStateMachine()
        {
            currentState.ExitState(this);
            stateMachineState = StateMachineState.Stopped;
            OnMachineStops.Invoke();
        }

        abstract public void StateChoosing();
        abstract protected void UpdateStates();

        private void Update() => UpdateStates();
    }
}