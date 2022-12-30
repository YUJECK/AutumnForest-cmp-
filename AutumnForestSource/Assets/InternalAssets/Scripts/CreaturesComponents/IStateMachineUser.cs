using AutumnForest;
using UnityEngine.Events;

namespace CreaturesAI
{
    public interface IStateMachineUser
    {
        public StateMachine StateMachine { get; }
        public CreatureServiceLocator CreatureServiceLocator { get; }
        public UnityEvent<State> OnStateChanged { get; } 
        public void StateChoosing();
    }
}   