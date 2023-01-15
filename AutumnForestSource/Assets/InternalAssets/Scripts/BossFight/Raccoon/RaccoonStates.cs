using AutumnForest.StateMachineSystem;

namespace AutumnForest.BossFight.Raccoon
{
    [System.Serializable]
    public sealed class RaccoonStateContainer
    {
        public State IdleState { get; private set; }
        public State DialogueState { get; private set; }
        public State ShootingState { get; private set; }
        public State ClothesThrowingState { get; private set; }
        public State HealingState { get; private set; }
        public State WaterJetState { get; private set; }
        public State SquirrelSpawnState { get; private set; }

        public RaccoonStateContainer(State idleState,
                                     State dialogueState,
                                     State shootinState,
                                     State clothesThrowingState,
                                     State healingState,
                                     State waterJetState,
                                     State squirrelSpawnState)
        {
            SquirrelSpawnState = squirrelSpawnState;
            DialogueState = dialogueState;
            ShootingState = shootinState;
            ClothesThrowingState = clothesThrowingState;
            HealingState = healingState;
            WaterJetState = waterJetState;
            SquirrelSpawnState = squirrelSpawnState;
        }
    }
}