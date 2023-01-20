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
        }
    }
}