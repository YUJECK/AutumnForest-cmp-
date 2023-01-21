using AutumnForest.StateMachineSystem;
using System;
using UnityEngine;

namespace AutumnForest.StateMachineTest
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(IStateContainerVariator))]
    public sealed class TestUser : MonoBehaviour, IStateMachineUser
    {
        public StateMachine StateMachine { get; private set; }
        public LocalServiceLocator ServiceLocator { get; private set; } 

        public event Action<StateBehaviour> OnStateChanged;

        private TestUserStateContainer stateContainer;

        private void OnEnable() => StateMachine.OnMachineWorking += StateChoosing;
        private void OnDisable() => StateMachine.OnMachineWorking -= StateChoosing;
        private void Awake()
        {
            stateContainer = GetComponent<IStateContainerVariator>().InitStates() as TestUserStateContainer;
            ServiceLocator = new(GetComponent<Rigidbody2D>(), GetComponent<SpriteRenderer>());
            
            StateMachine = new(this, true);
        }

        private void StateChoosing()
        {
            if (Input.GetKeyDown(KeyCode.A)) OnStateChanged.Invoke(stateContainer.AKeyState);
            if (Input.GetKeyDown(KeyCode.S)) OnStateChanged.Invoke(stateContainer.SKeyState);
            if (Input.GetKeyDown(KeyCode.D)) OnStateChanged.Invoke(stateContainer.DKeyState);
        }
    }
}