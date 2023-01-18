using AutumnForest.StateMachineSystem;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.BossFight.Fox
{
    public class FoxStateMachine : MonoBehaviour, IStateMachineUser
    {
        [Header("States")]
        [SerializeField] private StateBehaviour swordThrowingState;
        public UnityEvent<StateBehaviour> OnStateChanged => throw new System.NotImplementedException();

        public StateMachine StateMachine => throw new System.NotImplementedException();

        public CreatureServiceLocator ServiceLocator => throw new System.NotImplementedException();

        StateMachine IStateMachineUser.StateMachine => throw new NotImplementedException();

        event Action<StateBehaviour> IStateMachineUser.OnStateChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void InitServices()
        {
            throw new System.NotImplementedException();
        }

        public void StateChoosing()
        {
            StateBehaviour nextState = swordThrowingState;
            OnStateChanged.Invoke(nextState);
        }

        public void Update()
        {
        }
    }
}
