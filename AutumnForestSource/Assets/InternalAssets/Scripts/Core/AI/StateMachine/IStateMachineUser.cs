using System;

namespace AutumnForest.StateMachineSystem
{
    public interface IStateMachineUser
    {
        StateMachine StateMachine { get; }
        LocalServiceLocator ServiceLocator { get; }

        event Action<StateBehaviour> OnStateChanged;
    }
}