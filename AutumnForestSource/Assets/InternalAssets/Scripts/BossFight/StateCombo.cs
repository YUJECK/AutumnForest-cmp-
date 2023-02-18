namespace AutumnForest.StateMachineSystem
{
    public sealed class StateCombination : StateBehaviour
    {
        private StateBehaviour[] states;

        public StateCombination(params StateBehaviour[] states)
        {
            this.states = states;
        }

        public override void EnterState(IStateMachineUser stateMachine)
        {
            foreach (var item in states)
                item.EnterState(stateMachine);
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            foreach (var item in states)
                item.ExitState(stateMachine);
        }
    }
}