using AutumnForest.StateMachineSystem;
using System;
using UnityEngine;

namespace AutumnForest.StateMachineTest
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(IStateVariation))]
    public sealed class TestUser : MonoBehaviour, IStateMachineUser
    {
        public StateMachine StateMachine { get; private set; }
        public LocalServiceLocator ServiceLocator { get; private set; } 

        public event Action<StateBehaviour> OnStateChanged;

        private ColorStateContainer stateContainer;

        private void OnEnable() => StateMachine.OnMachineWorking += StateChoosing;
        private void OnDisable() => StateMachine.OnMachineWorking -= StateChoosing;
        private void Awake()
        {
            stateContainer = GetComponent<IStateVariation>().InitStates() as ColorStateContainer;
            ServiceLocator = new(GetComponent<SpriteRenderer>());
            StateMachine = new(this, true);
        }

        private void StateChoosing()
        {
            if (Input.GetKeyDown(KeyCode.A)) OnStateChanged.Invoke(stateContainer.State1);
            if (Input.GetKeyDown(KeyCode.S)) OnStateChanged.Invoke(stateContainer.State2);
            if (Input.GetKeyDown(KeyCode.D)) OnStateChanged.Invoke(stateContainer.State3);
        }
    }
}