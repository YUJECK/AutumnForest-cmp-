using AutumnForest.StateMachineSystem;
using AutumnForest.StateMachineTest;
using UnityEngine;

public class TestUserCBGStateVaritation : MonoBehaviour, IStateVariation
{
    public object InitStates() => new ColorStateContainer(
        new ColorSwitchState(Color.cyan),
        new ColorSwitchState(Color.blue),
        new ColorSwitchState(Color.green)
        );
}