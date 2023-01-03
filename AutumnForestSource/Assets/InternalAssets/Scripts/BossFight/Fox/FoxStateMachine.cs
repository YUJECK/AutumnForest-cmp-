using CreaturesAI;
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

        public void InitServices()
        {
            throw new System.NotImplementedException();
        }

        public void StateChoosing()
        {
            State nextState = swordThrowingState;
            OnStateChanged.Invoke(nextState);
        }
    }
}
