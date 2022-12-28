using CreaturesAI;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public class IdleRaccoonState : MonoBehaviour, IState
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string idleAnimationName = "RaccoonIdle";

        public float StateTransitionDelay { get; }

        public void EnterState(StateMachine stateMachine) => animator.Play(idleAnimationName);
        public void ExitState(StateMachine stateMachine) { }
        public void UpdateState(StateMachine stateMachine) => stateMachine.StateChoosing();
    }
}