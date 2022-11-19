public class IdleState : State
{
    public override void EnterState(AIController stateMachine) => stateMachine.animator.Play("RacconIdle");
    public override void ExitState(AIController stateMachine) { }
    public override void UpdateState(AIController stateMachine) => stateMachine.ChooseState();
}