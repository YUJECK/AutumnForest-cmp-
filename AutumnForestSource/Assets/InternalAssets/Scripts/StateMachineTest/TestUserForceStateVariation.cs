using AutumnForest.StateMachineSystem;
using UnityEngine;

namespace AutumnForest.StateMachineTest
{
    public sealed class TestUserForceStateVariation : MonoBehaviour, IStateContainerVariator
    {
        public IStateContainer InitStates() => new TestUserStateContainer(
            new TestState1(new Vector2(-10, 0)),
            new TestState1(new Vector2(10, 10)),
            new TestState1(new Vector2(0, -10)));
    }
}