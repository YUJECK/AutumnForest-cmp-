using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public Animator animator;
    protected State currentState;
    public Shooting shooting;
    public Combat combat;
    public Health health;

    abstract public void ChooseState();
    public void ChangeState(State newState)
    {
        if (currentState != null) currentState.ExitState(this);

        currentState = newState;
        currentState.EnterState(this);
    }

    private void Start() => ChooseState();
    private void Update() 
    {
        if(currentState != null)    
            currentState.UpdateState(this);
    } 
}