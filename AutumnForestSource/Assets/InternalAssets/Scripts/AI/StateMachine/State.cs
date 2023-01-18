using UnityEngine;

namespace AutumnForest.StateMachineSystem
{
    public abstract class State : MonoBehaviour
    {
        [property: SerializeField] public float StateTransitionDelay { get; }

        public virtual void EnterState(IStateMachineUser stateMachine) { }
        public virtual void UpdateState(IStateMachineUser stateMachine) { }
        public virtual void ExitState(IStateMachineUser stateMachine) { }
        
        public abstract void OnFoundNextState(IStateMachineUser stateMachine, State nextState);
    }
}