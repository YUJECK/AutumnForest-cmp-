using AutumnForest.BossFight.Raccoon;
using AutumnForest.BossFight.Raccoon.States;
using AutumnForest.BossFight.Squirrels;
using AutumnForest.DialogueSystem;
using AutumnForest.Projectiles;
using AutumnForest.Raccoon.States;
using AutumnForest.StateMachineSystem;
using UnityEngine;

namespace AutumnForest.Raccoon
{
    public class RaccoonStateVariator : MonoBehaviour, IStateContainerVariator
    {
        [Header("Prefabs")]
        [SerializeField] private Rigidbody2D chestnut;
        [SerializeField] private Projectile shirtPrefab;
        [SerializeField] private Squirrel defaultSquirrelPrefab;
        [SerializeField] private Squirrel fireSquirrelPrefab;
        [Space]
        [SerializeField] private AudioSource throwEffect;
        [SerializeField] private Dialogue dialogue;

        public IStateContainer InitStates()
        {
            StateBehaviour[] firstStageStates =
            {
                new RaccoonRoundShotState(throwEffect),
                new RaccoonSquirrelSpawnState(defaultSquirrelPrefab, 5, 7, 2.5f),
                new TripleShotState(chestnut, 10, 25, 0.5f)
            };
            StateBehaviour[] thirdStageStates =
            {
                new RaccoonRoundShotState(throwEffect),
                new RaccoonSquirrelSpawnState(defaultSquirrelPrefab, 5, 7, 2.5f)
            };

            return new RaccoonStatesContainer(
                new RaccoonIdleState(),
                new RaccoonDialogueState(dialogue),
                firstStageStates,
                thirdStageStates);
        }
    }
}