﻿using AutumnForest.StateMachineSystem;

namespace AutumnForest.BossFight.Raccoon
{
    public sealed class RaccoonStatesContainer : IStateContainer
    {
        public StateBehaviour IdleState { get; private set; }
        public StateBehaviour DialogueState { get; private set; }

        public StateBehaviour[] FirstStageStates { get; private set; }
        public StateBehaviour[] ThirdStageStates { get; private set; }


        public RaccoonStatesContainer(
            StateBehaviour idleState, 
            StateBehaviour dialogueState, 
            StateBehaviour[] firstStageStates,
            StateBehaviour[] thirdStageStates)
        {
            IdleState = idleState;
            DialogueState = dialogueState;

            FirstStageStates = firstStageStates;
            ThirdStageStates = thirdStageStates;
        }
    }
}