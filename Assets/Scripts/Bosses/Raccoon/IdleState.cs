public class IdleState : State
{
    public override void EnterState(StateMachine stateMachine) { }
    public override void ExitState(StateMachine stateMachine) { }
    public override void UpdateState(StateMachine stateMachine) => stateMachine.ChooseState();
}