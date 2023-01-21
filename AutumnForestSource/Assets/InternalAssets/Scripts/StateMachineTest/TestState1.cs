using AutumnForest.StateMachineSystem;
using UnityEngine;

namespace AutumnForest.StateMachineTest
{
    public sealed class TestState1 : StateBehaviour
    {
        Vector2 force;

        public TestState1(Vector2 force)
        {
            this.force = force;
        }

        public override void EnterState(IStateMachineUser stateMachine)
        {
            stateMachine.ServiceLocator.GetService<Rigidbody2D>().AddForce(this.force);
        }
    }
}