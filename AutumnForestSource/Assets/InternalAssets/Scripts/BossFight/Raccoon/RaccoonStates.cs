using AutumnForest.StateMachineSystem;

namespace AutumnForest.BossFight.Raccoon
{
    [System.Serializable]
    public sealed class RaccoonStateContainer
    {
        public StateBehaviour IdleState { get; private set; }
        public StateBehaviour DialogueState { get; private set; }
        public StateBehaviour ShootingState { get; private set; }
        public StateBehaviour ClothesThrowingState { get; private set; }
        public StateBehaviour HealingState { get; private set; }
        public StateBehaviour WaterJetState { get; private set; }
        public StateBehaviour SquirrelSpawnState { get; private set; }

        public RaccoonStateContainer(StateBehaviour idleState,
                                     StateBehaviour dialogueState,
                                     StateBehaviour shootinState,
                                     StateBehaviour clothesThrowingState,
                                     StateBehaviour healingState,
                                     StateBehaviour waterJetState,
                                     StateBehaviour squirrelSpawnState)
        {
            IdleState = idleState;
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