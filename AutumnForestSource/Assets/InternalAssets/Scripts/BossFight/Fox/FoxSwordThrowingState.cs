using AutumnForest.StateMachineSystem;
using CreaturesAI.CombatSkills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest.BossFight.Fox
{
    public sealed class FoxSwordThrowingState : StateBehaviour
    {
        public float StateTransitionDelay { get; }

        private Animator animator;
        private GameObject swordPrefab;
        private Transform[] swordPoints;
        private Shooting shooting;

        private Stack<GameObject> spawnedSwords = new Stack<GameObject>();


        private void OnDestroy()
        {
            //foreach (GameObject sword in spawnedSwords)
            //Destroy(sword);
        }

        private IEnumerator SwordThrowing(IStateMachineUser stateMachine)
        {
            //instantiate swords
            for (int i = 0; i < swordPoints.Length; i++)
            {
                spawnedSwords.Push(GameObject.Instantiate(swordPrefab, swordPoints[i].position, Quaternion.identity));
                yield return new WaitForSeconds(0.1f);
            }

            //shooting
            while (spawnedSwords.Count != 0)
            {
                if (spawnedSwords.Peek() != null)
                    shooting.ShootWithoutInstantiate(spawnedSwords.Peek(), 10, 0, 0, ForceMode2D.Impulse);
                spawnedSwords.Pop();
                yield return new WaitForSeconds(1.5f);
            }

            stateMachine.StateChoosing();
        }
        public override void EnterState(IStateMachineUser stateMachine)
        {
            animator.Play("FoxMagicBookOpen");
        }
    }
}