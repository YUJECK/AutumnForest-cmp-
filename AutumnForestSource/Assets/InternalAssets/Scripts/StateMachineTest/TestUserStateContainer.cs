using AutumnForest.StateMachineSystem;

namespace AutumnForest.StateMachineTest
{
    public sealed class TestUserStateContainer : IStateContainer
    {
        public StateBehaviour AKeyState { get; private set; }
        public StateBehaviour SKeyState { get; private set; }
        public StateBehaviour DKeyState { get; private set; }

        public TestUserStateContainer(StateBehaviour state1, StateBehaviour state2, StateBehaviour state3)
        {
            this.AKeyState = state1;
            this.SKeyState = state2;
            this.DKeyState = state3;
        }
    }
}