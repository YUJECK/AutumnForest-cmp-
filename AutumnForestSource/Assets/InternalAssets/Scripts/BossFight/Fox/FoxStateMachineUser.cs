using AutumnForest.BossFight.Fox.States;
using AutumnForest.Health;
using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Fox
{
    public class FoxStateMachineUser : MonoBehaviour, IStateMachineUser
    {
        [SerializeField] private ParticleSystem jumpParticle;
        [Header("Services")]
        [SerializeField] private Shooting shooting;
        [SerializeField] private FoxSoundsHelper foxSounds;
        [SerializeField] private Animator animator;
        [SerializeField] private CreatureHealth creatureHealth;
        [SerializeField] private Transform[] points;

        private FoxAnimator foxAnimator;

        public StateMachine StateMachine { get; private set; }
        public LocalServiceLocator ServiceLocator { get; private set; }

        public event Action<StateBehaviour> OnStateChanged;

        private StateBehaviour[] attackPatterns;

        private void Awake()
        {
            foxAnimator = new(animator);
            ServiceLocator = new(shooting, creatureHealth, foxAnimator, foxSounds);

            creatureHealth.OnDied += OnDie;

            StateBehaviour[] patterns =
            {
                new FoxTimingState(3.5f),
                new FoxFirstFlowerPattern(points, 1f),
                new FoxFirstFlowerPattern(points, 0.5f),
                new FoxSwordWandererSpawnState(),
                new FoxSerialSwordThowing(points, 0.1f, 0.5f),
            };
            attackPatterns = patterns;

            StateMachine = new(this, false);
            StateMachine.OnMachineWorking += StateChoosing;

            DisableObject();
        }
        private void OnEnable()
        {
            foxAnimator.PlayGrounded();
        }

        private void OnDie()
        {
            StateMachine.DisableStateMachine();
            foxAnimator.PlayJump();
        }
        private void DisableObject() => gameObject.SetActive(false); //for animator
        private void PlayJumpParticle() => jumpParticle.Play(); //for animator
        private void EnableStateMachine() => StateMachine.EnableStateMachine(); //for animator
        private void StateChoosing()
        {
            OnStateChanged?.Invoke(ObjectRandomizer.GetRandom(attackPatterns));
        }
    }
}