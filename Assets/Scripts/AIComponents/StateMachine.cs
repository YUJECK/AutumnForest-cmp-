using System.Linq.Expressions;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State currentState;
    public Animator animator;
    public Combat combat;
    public Health health;
    [SerializeField] private bool chooseStateOnAwake = true;

    abstract public void ChooseState();
    public void ChangeState(State newState)
    {
        if (currentState != null) currentState.ExitState(this);

        currentState = newState;
        currentState.EnterState(this);
    }

    private void Start() 
    {
        if (chooseStateOnAwake)
            ChooseState();
    }
    private void Update()
    {
        if (currentState != null)
            currentState.UpdateState(this);
    }
}