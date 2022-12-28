using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreaturesAI;
using CreaturesAI.CombatSkills;

namespace AutumnForest.BossFight.Fox
{
    public sealed class FoxSwordThrowingState : MonoBehaviour, IState
    {
        public float StateTransitionDelay { get; }
        
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject swordPrefab;
        [SerializeField] private Transform[] swordPoints;
        [SerializeField] private Shooting shooting;

        private Stack<GameObject> spawnedSwords = new Stack<GameObject>();


        private void OnDestroy()
        {
            foreach (GameObject sword in spawnedSwords)
                Destroy(sword);
        }

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
                    shooting.ShootWithoutInstantiate(spawnedSwords.Peek(), 10, 0, 0, ForceMode2D.Impulse);
                spawnedSwords.Pop();
                yield return new WaitForSeconds(1.5f);
            }

            stateMachine.StateChoosing();
        }
        public void EnterState(StateMachine stateMachine)
        {
            animator.Play("FoxMagicBookOpen");
            StartCoroutine(SwordThrowing(stateMachine));
        }
        public void ExitState(StateMachine stateMachine) { }
        public void UpdateState(StateMachine stateMachine) { }

        void IState.EnterState(StateMachine stateMachine)
        {
            throw new System.NotImplementedException();
        }

        void IState.UpdateState(StateMachine stateMachine)
        {
            throw new System.NotImplementedException();
        }

        void IState.ExitState(StateMachine stateMachine)
        {
            throw new System.NotImplementedException();
        }
    }
}