using UnityEngine;

public class RaccoonStateMachine : StateMachine
{
    [SerializeField] private Transform player;
    [SerializeField] private State idleState;
    [SerializeField] private State spawnQuirrelState;
    [SerializeField] private State shirtThrowingState;
    [SerializeField] private State roundState;

    public override void ChooseState()
    {
        State newState = idleState;

        switch (Random.Range(0, 3))
        {
            case 0:
                newState = roundState;
                break;
            case 1:
                newState = spawnQuirrelState;
                break;
            case 2:
                newState = shirtThrowingState;
                break;
        }

        ChangeState(newState);
    }
}
