namespace AutumnForest.StateMachineSystem
{
    public abstract class StateBehaviour
    {
        public virtual void EnterState(IStateMachineUser stateMachine) { }
        public virtual void UpdateState(IStateMachineUser stateMachine) { }
        public virtual void ExitState(IStateMachineUser stateMachine) { }

        public virtual bool CanEnterNewState() => true;
    }
}