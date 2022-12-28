using NaughtyAttributes;
using System.Collections;
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
        //variables
        //state info
        [Header("Some info")]
        private State currentState;
        [ReadOnly, SerializeField] private string currentStateName = "None";
        private StateMachineState stateMachineState = StateMachineState.Stopped;
        //events
        public UnityEvent OnMachineStarts = new();
        public UnityEvent OnMachineStops = new();

        //getters
        public State CurrentState => currentState;
        public StateMachineState StateMachineState => stateMachineState;

        //constant methods
        protected void ChangeState(State newState)
        {
            Debug.Log(newState.StateName);

            if (currentState != null && currentState.StateTransitionDelay != 0f)
                StartCoroutine(EnterNewState(newState, currentState.StateTransitionDelay));
            else EnterNewState(newState);
        }
        private void EnterNewState(State newState)
        {
            if (newState != null)
            {
                if (currentState != null) currentState.ExitState(this);
                currentState = newState;
                currentStateName = currentState.StateName;
                currentState.EnterState(this);
            }
        }
        private IEnumerator EnterNewState(State newState, float delay)
        {
            if (currentState != null) currentState.ExitState(this);
            else currentState = null;

            yield return new WaitForSeconds(delay);

            if (newState != null)
            {
                currentState = newState;
                currentStateName = currentState.StateName;
                currentState.EnterState(this);
            }
        }

        //abstract methods
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

        //unity methods
        private void Update() => UpdateStates();
    }
}