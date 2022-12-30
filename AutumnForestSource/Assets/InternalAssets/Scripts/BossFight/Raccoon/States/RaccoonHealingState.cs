using CreaturesAI;
using CreaturesAI.Health;
using System.Collections;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public class RaccoonHealingState : State
    {
        [SerializeField] private Health health;
        [SerializeField] private Animator animator;
        [SerializeField] private Transform healingPoint;
        [SerializeField] private Transform defaultPoint;

        public float StateTransitionDelay { get; }

        private IEnumerator Healing(StateMachine stateMachine)
        {
            animator.Play("RaccoonJumpAway");
            yield return new WaitForSeconds(0.21f);
            stateMachine.transform.position = healingPoint.position;

            while (true)
            {
                health.Heal(2);
                yield return new WaitForSeconds(3);
            }
        }

        //public void EnterState(StateMachine stateMachine) => StartCoroutine(Healing(stateMachine));
        public void ExitState(StateMachine stateMachine)
        {
            stateMachine.transform.position = defaultPoint.position;
            //StopAllCoroutines();
        }
        public void UpdateState(StateMachine stateMachine) { }
    }
}