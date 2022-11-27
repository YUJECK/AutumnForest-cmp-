using CreaturesAI.Pathfinding;
using System.Collections;
using UnityEngine;

namespace CreaturesAI
{
    abstract public class StateMachine : MonoBehaviour
    {
        //variables
        //state info
        [Header("Some info")]
        private State currentState;
        [SerializeField] private string currentStateName;

        //some components
        [Header("Components")]
        [SerializeField] private Animator animator;
        [SerializeField] private Shooting shooting;
        [SerializeField] private Moving moving;
        [SerializeField] private TargetSelection targetSelection;
        [SerializeField] private DynamicPathfinding dymamicPathfinding;
        [SerializeField] private Health health;
        [SerializeField] private Combat combat;
        [SerializeField] private Dialogue dialogue;

        //getters
        protected State CurrentState => currentState;
        public Moving Moving => moving;
        public Shooting Shooting => shooting;
        public TargetSelection TargetSelection => targetSelection;
        public DynamicPathfinding DynamicPathfinding => dymamicPathfinding;
        public Health Health => health;
        public Combat Combat => combat;
        public Dialogue Dialogue => dialogue;
        public Animator Animator => animator;

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
        abstract public void StateChoosing();
        abstract protected void UpdateStates();

        //unity methods
        private void Update() => UpdateStates();
    }
}