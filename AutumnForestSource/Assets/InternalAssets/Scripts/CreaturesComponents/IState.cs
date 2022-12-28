using UnityEngine;

namespace CreaturesAI
{
    public interface IState
    {
        [property: SerializeField] public float StateTransitionDelay { get; }
        
        public void EnterState(StateMachine stateMachine);
        public void UpdateState(StateMachine stateMachine);
        public void ExitState(StateMachine stateMachine);
    }
}