using CreaturesAI;
using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    public class SquirrelSpawnState : State
    {
        [SerializeField] private GameObject squirrel;
        [SerializeField] private Transform[] spawnPoints;

        private IEnumerator SquirellSpawn(StateMachine stateMachine)
        {
            stateMachine.Animator.Play("Idle");

            int squirrelsCount = Random.Range(2, 3);

            for (int i = 0; i < squirrelsCount; i++)
            {
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);

                if (Physics2D.Raycast(spawnPoints[spawnPointIndex].position, Vector2.zero).transform == null)
                {
                    Instantiate(squirrel, spawnPoints[spawnPointIndex].position, Quaternion.identity);
                    yield return new WaitForSeconds(2f);
                }
                else i--;
            }

            stateMachine.StateChoosing();
        }

        public override void EnterState(StateMachine stateMachine) => StartCoroutine(SquirellSpawn(stateMachine)); 
        public override void ExitState(StateMachine stateMachine) => StopAllCoroutines();
        public override void UpdateState(StateMachine stateMachine) { }
    }
}