using System.Collections;
using UnityEngine;

abstract public class State : MonoBehaviour
{
    abstract public void EnterState(AIController stateMachine);
    abstract public void UpdateState(AIController stateMachine);
    abstract public void ExitState(AIController stateMachine);
}