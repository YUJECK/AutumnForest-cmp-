using System;

namespace AutumnForest.StateMachineSystem
{
    public interface IStateMachineUser
    {
        StateMachine StateMachine { get; }
        CreatureServiceLocator CreatureServiceLocator { get; }

        event Action<State> OnStateChanged;

        void InitServices();
        void StateChoosing();
        void Update();
    }
}