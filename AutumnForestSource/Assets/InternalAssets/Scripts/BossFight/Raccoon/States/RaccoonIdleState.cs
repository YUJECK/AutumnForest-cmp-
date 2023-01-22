using AutumnForest.StateMachineSystem;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonIdleState : StateBehaviour
    {
        public override void EnterState(IStateMachineUser stateMachine)
        {
            Debug.Log("idle state");
            stateMachine.ServiceLocator.GetService<CreatureAnimator>().SetDefault();
        }
    }
}