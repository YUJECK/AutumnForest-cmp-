﻿using AutumnForest.BossFight.Raccoon;
using AutumnForest.BossFight.Raccoon.States;
using AutumnForest.BossFight.Squirrels;
using AutumnForest.BossFight.States;
using AutumnForest.DialogueSystem;
using AutumnForest.Raccoon.States;
using AutumnForest.StateMachineSystem;
using UnityEngine;

namespace AutumnForest.Raccoon
{
    public class RaccoonStateVariator : MonoBehaviour, IStateContainerVariator
    {
        [Header("Configs")]
        [SerializeField] private RandomShotStateConfig randomShotStateConfig;
        [SerializeField] private RacconHealingStateConfig racconHealingStateConfig;
        [SerializeField] private RaccoonRoundShotStateConfig raccoonRoundShotStateConfig;
        [SerializeField] private RaccoonShirtThrowingStateConfig raccoonShirtThrowingStateConfig;
        [Header("Prefabs")]
        [SerializeField] private Rigidbody2D chestnut;
        [SerializeField] private Squirrel defaultSquirrelPrefab;
        [SerializeField] private Squirrel fireSquirrelPrefab;
        [Space]
        [SerializeField] private Dialogue dialogue;
        [SerializeField] private GameObject waterJet;
        [SerializeField] private Transform healPoint;
        [SerializeField] private Transform defaultPosition;

        public IStateContainer InitStates()
        {
            StateBehaviour[] firstStageStates =
            {
                new RaccoonRandomShotState(randomShotStateConfig),
                new RaccoonRoundShotState(raccoonRoundShotStateConfig),
                new RaccoonShirtThrowingState(raccoonShirtThrowingStateConfig),
                new RaccoonSquirrelSpawnState(defaultSquirrelPrefab, 5, 7, 2.5f),
                new TripleShotState(chestnut, 10, 25, 0.5f)
            };
            StateBehaviour[] thirdStageStates =
            {
                new RaccoonRoundShotState(raccoonRoundShotStateConfig),
                new RaccoonSquirrelSpawnState(defaultSquirrelPrefab, 3, 4, 1.5f),
            };

            return new RaccoonStatesContainer(
                new RaccoonIdleState(),
                new RaccoonDialogueState(dialogue),
                new RaccoonHealingState(racconHealingStateConfig, healPoint, defaultPosition),
                firstStageStates,
                thirdStageStates);
        }
    }
}