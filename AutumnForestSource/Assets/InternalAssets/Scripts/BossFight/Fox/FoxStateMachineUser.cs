using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using System;
using UnityEngine;

namespace AutumnForest
{
    public class FoxStateMachineUser : MonoBehaviour, IStateMachineUser
    {
        public StateMachine StateMachine { get; private set; }
        public LocalServiceLocator ServiceLocator { get; private set; }

        public event Action<StateBehaviour> OnStateChanged;

        public StateBehaviour[] attackPatterns; 

        [Header("Services")]
        [SerializeField] private Shooting shooting;
        [SerializeField] private CreatureAnimator creatureAnimator;

        private void Awake()
        {
            ServiceLocator = new(shooting, creatureAnimator);
            StateMachine = new(this, false);

            StateMachine.OnMachineWorking += StateChoosing;
        }

        private void StateChoosing()
        {
            OnStateChanged?.Invoke(ObjectRandomizer.GetRandom(attackPatterns));
        }
    }
}