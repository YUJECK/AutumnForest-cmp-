using AutumnForest;
using AutumnForest.Helpers;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace CreaturesAI
{
    public enum StateMachineCondition
    {
        Working,
        Stopped
    }

    [DisallowMultipleComponent]
    [RequireComponent(typeof(CreatureServiceLocator))]
    [RequireComponent(typeof(IStateMachineUser))]
    public class StateMachine : MonoBehaviour, ICreatureComponent
    {
        [SerializeField] private bool enableOnStart = true;
        private IStateMachineUser stateMachineUser;

        public UnityEvent OnMachineEnabled { get; } = new();
        public UnityEvent OnMachineDisabled { get; } = new();

        public State CurrentState { get; private set; }
        public StateMachineCondition StateMachineState { get; private set; }

        private void OnEnable()
        {
            stateMachineUser = GetComponent<IStateMachineUser>();
            stateMachineUser.OnStateChanged.AddListener(ChangeState);
        }
        private void Start()
        {
            if (enableOnStart)
                EnableStateMachine();
        }

        private async void ChangeState(State newState)
        {
            if (newState != null)
            {
                if (CurrentState != null) CurrentState.ExitState(stateMachineUser);
                int waitTime = (int)(CurrentState.StateTransitionDelay * 1000);
                CurrentState = null;

                await Task.Delay(waitTime);

                CurrentState = newState;
                CurrentState.EnterState(stateMachineUser);
            }
            else Debug.LogError("New State is null");
        }

        public void EnableStateMachine()
        {
            if (StateMachineState != StateMachineCondition.Working)
            {
                stateMachineUser.StateChoosing();
                StateMachineState = StateMachineCondition.Working;
                OnMachineEnabled.Invoke();
            }
        }
        public void DisableStateMachine()
        {
            CurrentState.ExitState(stateMachineUser);
            StateMachineState = StateMachineCondition.Stopped;
            OnMachineDisabled.Invoke();
        }
    }
}