namespace AutumnForest.StateMachineSystem
{
    public abstract class StateBehaviour
    {
        public bool IsCompleted { get; protected set; } = false;

        public virtual void EnterState(IStateMachineUser stateMachine) { }
        public virtual void UpdateState(IStateMachineUser stateMachine) { }
        public virtual void ExitState(IStateMachineUser stateMachine) { }

        public virtual bool CanExit() => IsCompleted;
        public virtual bool Repeatable() => true;
    }
}