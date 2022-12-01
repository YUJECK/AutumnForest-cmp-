using CreaturesAI;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace AutumnForest
{
    public class RaccoonHealingState : State
    {
        [SerializeField] private Transform healingPoint;
        [SerializeField] private Transform defaultPoint;

        private IEnumerator Healing(StateMachine stateMachine)
        {
            while (true)
            {
                stateMachine.Health.Heal(2);
                yield return new WaitForSeconds(3);
            }
        }

        public override void EnterState(StateMachine stateMachine)
        {
            stateMachine.transform.position = healingPoint.position;
            StartCoroutine(Healing(stateMachine));
        }
        public override void ExitState(StateMachine stateMachine)
        {
            stateMachine.transform.position = defaultPoint.position;
            StopCoroutine(Healing(stateMachine));
        }
        public override void UpdateState(StateMachine stateMachine) { }
    }
}