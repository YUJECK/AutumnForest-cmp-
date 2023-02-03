using AutumnForest.BossFight.Fox.States;
using AutumnForest.Health;
using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using System;
using UnityEngine;

namespace AutumnForest
{
    public class FoxStateMachineUser : MonoBehaviour, IStateMachineUser
    {
        [Header("Services")]
        [SerializeField] private Shooting shooting;
        [SerializeField] private CreatureAnimator creatureAnimator;
        [SerializeField] private CreatureHealth creatureHealth;
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
                new FoxTurnedRoundSwordThrowingState(0.2f, 15, points),
                new FoxTurnedRoundSwordThrowingState(0.1f, 20 , points)
            };

            attackPatterns = patterns;

            ServiceLocator = new(shooting, creatureHealth);
            StateMachine = new(this, false);

            StateMachine.OnMachineWorking += StateChoosing;

            gameObject.SetActive(false);
        }

        private void StateChoosing()
        {
            OnStateChanged?.Invoke(ObjectRandomizer.GetRandom(attackPatterns));
        }
    }
}