using UnityEngine;

namespace AutumnForest.StateMachineSystem
{
    public abstract class StateBehaviour 
    {
        [property: SerializeField] public float StateTransitionDelay { get; }

        public virtual void EnterState(IStateMachineUser stateMachine) { }
        public virtual void UpdateState(IStateMachineUser stateMachine) { }
        public virtual void ExitState(IStateMachineUser stateMachine) { }

        public virtual bool CanEnterNewState() => true;
    }
}