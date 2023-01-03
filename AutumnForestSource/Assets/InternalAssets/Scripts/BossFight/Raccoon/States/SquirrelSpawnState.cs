using CreaturesAI;
using System.Threading.Tasks;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public class SquirrelSpawnState : State
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject squirrel;
        [SerializeField] private Transform[] spawnPoints;

        private async void SquirellSpawn(IStateMachineUser stateMachine)
        {
            animator.Play("Idle");

            int squirrelsCount = Random.Range(2, 3);
            int squirrelSpawnDelay = 2000;

            for (int i = 0; i < squirrelsCount; i++)
            {
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);

                if (Physics2D.Raycast(spawnPoints[spawnPointIndex].position, Vector2.zero).transform == null)
                {
                    GameObject.Instantiate(squirrel, spawnPoints[spawnPointIndex].position, Quaternion.identity);
                    await Task.Delay(squirrelSpawnDelay);
                }
                else i--;
            }

            stateMachine.StateChoosing();
        }
        public override void EnterState(IStateMachineUser stateMachine) => SquirellSpawn(stateMachine);
    }
}