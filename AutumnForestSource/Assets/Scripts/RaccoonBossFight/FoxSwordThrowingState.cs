using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreaturesAI;

namespace AutumnForest
{
    public class FoxSwordThrowingState : State
    {
        [SerializeField] private GameObject swordPrefab;
        [SerializeField] private Transform[] swordPoints;

        private Stack<GameObject> spawnedSwords = new Stack<GameObject>();


        private IEnumerator SwordThrowing(StateMachine stateMachine)
        {
            //instantiate swords
            for (int i = 0; i < swordPoints.Length; i++)
            {
                spawnedSwords.Push(Instantiate(swordPrefab, swordPoints[i].position, Quaternion.identity));
                yield return new WaitForSeconds(0.1f);
            }

            //shooting
            while(spawnedSwords.Count != 0)
            {
                if(spawnedSwords.Peek() != null)
                    stateMachine.Shooting.ShootWithoutInstantiate(spawnedSwords.Peek(), 10, 0, 0, ForceMode2D.Impulse);
                spawnedSwords.Pop();
                yield return new WaitForSeconds(1.5f);
            }

            stateMachine.StateChoosing();
        }
        public override void EnterState(StateMachine stateMachine)
        {
            stateMachine.Animator.Play("FoxMagicBookOpen");
            StartCoroutine(SwordThrowing(stateMachine));
        }

        public override void ExitState(StateMachine stateMachine) { }
        public override void UpdateState(StateMachine stateMachine) { }
    }
}