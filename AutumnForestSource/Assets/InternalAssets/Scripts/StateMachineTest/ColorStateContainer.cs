using AutumnForest.StateMachineSystem;

namespace AutumnForest.StateMachineTest
{
    public sealed class ColorStateContainer
    {
        public StateBehaviour State1 { get; private set; }
        public StateBehaviour State2 { get; private set; }
        public StateBehaviour State3 { get; private set; }

        public ColorStateContainer(StateBehaviour state1, StateBehaviour state2, StateBehaviour state3)
        {
            this.State1 = state1;
            this.State2 = state2;
            this.State3 = state3;
        }
    }
}