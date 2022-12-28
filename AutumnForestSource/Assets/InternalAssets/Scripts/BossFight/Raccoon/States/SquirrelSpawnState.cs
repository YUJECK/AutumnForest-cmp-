using CreaturesAI;
using System.Collections;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public class SquirrelSpawnState : MonoBehaviour, IState
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject squirrel;
        [SerializeField] private Transform[] spawnPoints;
        public float StateTransitionDelay { get; }

        private IEnumerator SquirellSpawn(StateMachine stateMachine)
        {
            animator.Play("Idle");

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

        public void EnterState(StateMachine stateMachine) => StartCoroutine(SquirellSpawn(stateMachine)); 
        public void ExitState(StateMachine stateMachine) => StopAllCoroutines();
        public void UpdateState(StateMachine stateMachine) { }
    }
}