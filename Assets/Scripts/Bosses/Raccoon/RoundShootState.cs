using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundShootState : State
{
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject projectile;
    [SerializeField] private int projectilesFromPoint = 6;

    public override void EnterState(StateMachine stateMachine)
    {
        StartCoroutine(Shooting(stateMachine));
        stateMachine.animator.Play("RaccoonRun");
    }
    protected IEnumerator StateExitDelay(float delay, StateMachine stateMachine)
    {
        yield return new WaitForSeconds(delay);
        stateMachine.ChooseState();
    }
    private IEnumerator Shooting(StateMachine stateMachine)
    {
        int currentPoint = 0;
        for(int i = 0; i < points.Length*6; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(projectile, points[currentPoint].position, points[currentPoint].rotation);
            
            currentPoint++;
            if (currentPoint >= points.Length) currentPoint = 0;
        }

        
        StartCoroutine(StateExitDelay(3f, stateMachine));
    }

    public override void ExitState(StateMachine stateMachine) { StopAllCoroutines(); }
    public override void UpdateState(StateMachine stateMachine) { }
}