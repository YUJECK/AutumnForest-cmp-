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
            foreach (GameObject sword in spawnedSwords)
            {
                stateMachine.Shooting.ShootWithInstantiate(sword, 15, 0, 0, ForceMode2D.Impulse);
                yield return new WaitForSeconds(1.5f);
            }

            stateMachine.StateChoosing();
        }
        public override void EnterState(StateMachine stateMachine)
        {
            for (int i = 0; i < swordPoints.Length; i++)
                spawnedSwords.Push(Instantiate(swordPrefab, swordPoints[i].position, Quaternion.identity));

            StartCoroutine(SwordThrowing(stateMachine));
        }

        public override void ExitState(StateMachine stateMachine) { }
        public override void UpdateState(StateMachine stateMachine) { }
    }
}