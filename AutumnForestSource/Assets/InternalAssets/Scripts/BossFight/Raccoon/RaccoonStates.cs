using CreaturesAI;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public partial class RaccoonStateMachine
    {
        [System.Serializable]
        private class RaccoonStates
        {
            [Header("States")]
            [SerializeField] private State idleState;
            [Header("First Stage States")]
            [SerializeField] private State dialogueState;
            [SerializeField] private State shootingState;
            [SerializeField] private State clothesThrowingState;
            [Header("Second Stage States")]
            [SerializeField] private State healingState;
            [Header("Third Stage States")]
            [SerializeField] private State waterJetState;
            [SerializeField] private State squirrelSpawnState;

            public State IdleState => idleState;
            public State DialogueState => dialogueState;
            public State ShootingState => shootingState;
            public State ClothesThrowingState => clothesThrowingState;
            public State HealingState => healingState;
            public State WaterJetState => waterJetState;
            public State SquirrelSpawnState => squirrelSpawnState;
        }
    }
}