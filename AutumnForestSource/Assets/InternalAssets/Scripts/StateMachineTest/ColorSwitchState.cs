using AutumnForest.StateMachineSystem;
using UnityEngine;

namespace AutumnForest.StateMachineTest
{
    public sealed class ColorSwitchState : StateBehaviour
    {
        private Color switchColor = Color.white;

        public ColorSwitchState(Color color) 
        {
            this.switchColor = color;
        }

        public override void EnterState(IStateMachineUser stateMachine)
        {
            stateMachine.ServiceLocator.GetService<SpriteRenderer>().color = this.switchColor;
            Debug.Log($"Entered {switchColor} state");
        }
        public override void UpdateState(IStateMachineUser stateMachine)
        {
            Debug.Log($"Current state is {switchColor} state");
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            Debug.Log($"{switchColor} state exit");
        }
    }
}