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
        [SerializeField] private Projectile shirtPrefab;
        [SerializeField] private Squirrel defaultSquirrelPrefab;
        [SerializeField] private Squirrel fireSquirrelPrefab;
        [Space]
        [SerializeField] private AudioSource throwEffect;
        [SerializeField] private Dialogue dialogue;

        public IStateContainer InitStates()
        {
            return new RaccoonStatesContainer(
                new RaccoonIdleState(),
                new RaccoonRoundShotState(throwEffect),
                //да мне лень было добавлять отдельные поля для настройки состояний
                new RaccoonSquirrelSpawnState(defaultSquirrelPrefab, 5, 7, 2.5f),
                new RaccoonDialogueState(dialogue));
            //new RaccoonSquirrelSpawnState(fireSquirrelPrefab, 3, 5, 2.5f));
        }
    }
}