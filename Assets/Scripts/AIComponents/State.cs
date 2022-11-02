using System.Collections;
using UnityEngine;

abstract public class State : MonoBehaviour
{
    abstract public void EnterState(StateMachine stateMachine);
    abstract public void UpdateState(StateMachine stateMachine);
    abstract public void ExitState(StateMachine stateMachine);
}