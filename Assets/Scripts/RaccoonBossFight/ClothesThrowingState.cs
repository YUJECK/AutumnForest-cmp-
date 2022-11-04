using System.Collections;
using UnityEngine;

public class ClothesThrowingState : State
{
    [SerializeField] private GameObject shirtPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform target;

    public override void EnterState(StateMachine stateMachine) => StartCoroutine(ThrowingShirts(Random.Range(2, 4), stateMachine));
    private IEnumerator ThrowingShirts(int shirtsCount, StateMachine stateMachine)
    {
        stateMachine.animator.Play("RaccoonThrowing");

        for (int i = 0; i < shirtsCount; i++)
        {
            Instantiate(shirtPrefab, target.position, target.rotation);
            yield return new WaitForSeconds(1.5f);
        }

        StartCoroutine(StateExitDelay(2f, stateMachine));
    }
    protected IEnumerator StateExitDelay(float delay, StateMachine stateMachine)
    {
        yield return new WaitForSeconds(delay);
        stateMachine.ChooseState();
    }
    public override void ExitState(StateMachine stateMachine) => StopAllCoroutines();
    public override void UpdateState(StateMachine stateMachine) { }
}
