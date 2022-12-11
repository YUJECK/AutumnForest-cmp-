using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class FirstBossFightStage : State
    {


        public override void EnterState(StateMachine stateMachine)
        {
            ServiceLocator.GetService<RaccoonStateMachine>().StateChoosing();
        }

        public override void ExitState(StateMachine stateMachine)
        {
        }

        public override void UpdateState(StateMachine stateMachine)
        {
            stateMachine.StateChoosing();
        }
    }
}