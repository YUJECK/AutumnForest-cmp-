using CreaturesAI;
using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    public class ClothesThrowingState : State
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string throwingAnimationName = "RaccoonThrowing";
        [SerializeField] private GameObject shirt;
        [SerializeField] private int shirtsCount;

        private IEnumerator Throwing(StateMachine stateMachine)
        {
            for (int i = 0; i < shirtsCount; i++)
            {
                Instantiate(shirt, ObjectList.Player.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }

            stateMachine.StateChoosing();
        }

        public override void EnterState(StateMachine stateMachine)
        {
            animator.Play(throwingAnimationName);
            StartCoroutine(Throwing(stateMachine));
        }
        public override void ExitState(StateMachine stateMachine) => StopAllCoroutines();
        public override void UpdateState(StateMachine stateMachine) { }
    }
}