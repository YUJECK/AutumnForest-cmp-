using AutumnForest.StateMachineSystem;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon.States
{
    public sealed class RaccoonIdleState : StateBehaviour
    {
        public override void EnterState(IStateMachineUser stateMachine)
        {
            Debug.Log("asdsd");
            stateMachine.ServiceLocator.GetService<CreatureAnimator>().SetDefault();
        }
        public override void UpdateState(IStateMachineUser stateMachine)
        {
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
        }
    }
}