using AutumnForest.StateMachineSystem;
using System;
using UnityEngine;

namespace AutumnForest.StateMachineTest
{
    public sealed class TestUser : MonoBehaviour, IStateMachineUser
    {
        public StateMachine StateMachine { get; private set; }
        public LocalServiceLocator ServiceLocator { get; private set; } 

        public event Action<StateBehaviour> OnStateChanged;

        private StateBehaviour state1 = new ColorSwitchState(Color.cyan);
        private StateBehaviour state2 = new ColorSwitchState(Color.green);
        private StateBehaviour state3 = new ColorSwitchState(Color.blue);

        private void Awake()
        {
            ServiceLocator = new(GetComponent<SpriteRenderer>());
            StateMachine = new(this, true, StateChoosing);
        }

        private void StateChoosing()
        {
            if (Input.GetKeyDown(KeyCode.A))
                OnStateChanged.Invoke(state1);
            if (Input.GetKeyDown(KeyCode.S))
                OnStateChanged.Invoke(state2);
            if (Input.GetKeyDown(KeyCode.D))
                OnStateChanged.Invoke(state3);
        }
    }
}