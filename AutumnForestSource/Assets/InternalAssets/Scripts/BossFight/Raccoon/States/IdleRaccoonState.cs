using CreaturesAI;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public class IdleRaccoonState : State
    {
        [SerializeField] private string idleAnimationName = "RaccoonIdle";
        [SerializeField] private Animator animator;

        public override void EnterState(IStateMachineUser stateMachine) => animator.Play(idleAnimationName);
        public override void UpdateState(IStateMachineUser stateMachine) => stateMachine.StateChoosing();
    }
}