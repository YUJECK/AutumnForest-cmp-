using CreaturesAI;
using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    public class SquirrelSpawnState : State
    {
        [SerializeField] private GameObject squirrel;
        [SerializeField] private Transform[] spawnPoints;

        private IEnumerator SquirellSpawn()
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(squirrel, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                yield return new WaitForSeconds(1.5f);
            }
        }

        public override void EnterState(StateMachine stateMachine)
        {
            StartCoroutine(SquirellSpawn());
        }

        public override void ExitState(StateMachine stateMachine)
        {
            StopAllCoroutines();
        }

        public override void UpdateState(StateMachine stateMachine)
        {
        }
    }
}