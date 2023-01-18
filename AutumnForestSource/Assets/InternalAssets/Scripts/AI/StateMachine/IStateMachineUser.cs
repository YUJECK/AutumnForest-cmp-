using System;

namespace AutumnForest.StateMachineSystem
{
    public interface IStateMachineUser
    {
        StateMachine StateMachine { get; }
        CreatureServiceLocator ServiceLocator { get; }

        event Action<StateBehaviour> OnStateChanged;

        void StateChoosing();
    }
}