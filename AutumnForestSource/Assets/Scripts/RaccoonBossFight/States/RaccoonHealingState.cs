using CreaturesAI;
using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonHealingState : State
    {
        [SerializeField] private Transform healingPoint;
        [SerializeField] private Transform defaultPoint;

        private IEnumerator Healing(StateMachine stateMachine)
        {
            stateMachine.Animator.Play("RaccoonJumpAway");
            yield return new WaitForSeconds(0.21f);
            stateMachine.transform.position = healingPoint.position;

            while (true)
            {
                stateMachine.Health.Heal(2);
                yield return new WaitForSeconds(3);
            }
        }

        public override void EnterState(StateMachine stateMachine) => StartCoroutine(Healing(stateMachine));
        public override void ExitState(StateMachine stateMachine)
        {
            stateMachine.transform.position = defaultPoint.position;
            StopAllCoroutines();
        }
        public override void UpdateState(StateMachine stateMachine) { }
    }
}