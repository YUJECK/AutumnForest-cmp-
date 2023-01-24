using AutumnForest.StateMachineSystem;

namespace AutumnForest.BossFight.Raccoon
{
    public sealed class RaccoonStatesContainer : IStateContainer
    {
        public StateBehaviour IdleState { get; private set; }
        public StateBehaviour ConeRoundShotState { get; private set; }


        public RaccoonStatesContainer(StateBehaviour idleState, StateBehaviour coneRoundShotState)
        {
            IdleState = idleState;
            ConeRoundShotState = coneRoundShotState;
        }
    }
}