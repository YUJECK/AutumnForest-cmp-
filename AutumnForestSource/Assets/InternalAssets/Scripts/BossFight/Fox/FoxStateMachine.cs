using AutumnForest.StateMachineSystem;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.BossFight.Fox
{
    public class FoxStateMachine : MonoBehaviour, IStateMachineUser
    {
        [Header("States")]
        [SerializeField] private State swordThrowingState;
        public UnityEvent<State> OnStateChanged => throw new System.NotImplementedException();

        public StateMachine StateMachine => throw new System.NotImplementedException();

        public CreatureServiceLocator CreatureServiceLocator => throw new System.NotImplementedException();

        StateMachine IStateMachineUser.StateMachine => throw new NotImplementedException();

        event Action<State> IStateMachineUser.OnStateChanged
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
            State nextState = swordThrowingState;
            OnStateChanged.Invoke(nextState);
        }

        public void Update()
        {
        }
    }
}
