using AutumnForest.StateMachineSystem;
using AutumnForest.StateMachineTest;
using UnityEngine;

public class TestUserColorStateVaritator : MonoBehaviour, IStateContainerVariator
{
    public IStateContainer InitStates() => new TestUserStateContainer(
        new ColorSwitchState(Color.cyan),
        new ColorSwitchState(Color.blue),
        new ColorSwitchState(Color.green)
        );
}