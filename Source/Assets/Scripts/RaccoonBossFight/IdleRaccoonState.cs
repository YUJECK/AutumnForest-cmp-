using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    [CreateAssetMenu()]
    public class IdleRaccoonState : State
    {
        [SerializeField] private string idleAnimationName = "RaccoonIdle";

        public override void EnterState(StateMachine stateMachine) => stateMachine.Animator.Play(idleAnimationName);

        public override void ExitState(StateMachine stateMachine) { }

        public override void UpdateState(StateMachine stateMachine) => stateMachine.StateChoosing();
    }
}