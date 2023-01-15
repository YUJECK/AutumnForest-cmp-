using AutumnForest;
using System;

namespace CreaturesAI
{
    public interface IStateMachineUser
    {
        public StateMachine StateMachine { get; }
        public CreatureServiceLocator CreatureServiceLocator { get; }

        public event Action<State> OnStateChanged;

        public void InitServices();
        public void StateChoosing();
        public void Update();
    }
}