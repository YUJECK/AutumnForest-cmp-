using AutumnForest.BossFight.Fox.States;
using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AutumnForest
{
    public class FoxStateMachineUser : MonoBehaviour, IStateMachineUser
    {
        [Header("Services")]
        [SerializeField] private Shooting shooting;
        [SerializeField] private CreatureAnimator creatureAnimator;
        [SerializeField] private Transform[] points;
        public StateMachine StateMachine { get; private set; }
        public LocalServiceLocator ServiceLocator { get; private set; }

        public event Action<StateBehaviour> OnStateChanged;

        private StateBehaviour[] attackPatterns;

        private void Awake()
        {
            StateBehaviour[] patterns =
            {
                new FoxFirstFlowerPattern(points),
            };
            attackPatterns = patterns;

            ServiceLocator = new(shooting);
            StateMachine = new(this, true);

            StateMachine.OnMachineWorking += StateChoosing;
        }

        private void StateChoosing()
        {
            OnStateChanged?.Invoke(ObjectRandomizer.GetRandom(attackPatterns));
        }
    }
}