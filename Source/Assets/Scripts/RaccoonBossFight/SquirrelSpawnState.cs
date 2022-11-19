using System.Collections;
using UnityEngine;

public class SquirrelSpawnState : State
{
    [SerializeField] private GameObject squirell;
    [SerializeField] private Transform[] spawnPoints;

    public override void EnterState(AIController stateMachine) => StartCoroutine(SpawnSquirrels(stateMachine));
    protected IEnumerator StateExitDelay(float delay, AIController stateMachine)
    {
        yield return new WaitForSeconds(delay);
        stateMachine.ChooseState();
    }
    private IEnumerator SpawnSquirrels(AIController stateMachine)
    {
        stateMachine.animator.Play("Idle");

        Debug.Log("Debug");
        int squirrelsCount = Random.Range(2, 3);

        for (int i = 0; i < squirrelsCount; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            if (Physics2D.Raycast(spawnPoints[spawnPointIndex].position, Vector2.zero).transform == null)
            {
                Instantiate(squirell, spawnPoints[spawnPointIndex].position, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
            else i--;
        }

        StartCoroutine(StateExitDelay(3f, stateMachine));
    }
    public override void ExitState(AIController stateMachine) => StopAllCoroutines();
    public override void UpdateState(AIController stateMachine) { }
}