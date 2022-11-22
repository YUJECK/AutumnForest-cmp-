using CreaturesAI;
using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    [CreateAssetMenu()]
    public class ClothesThrowingState : State
    {
        [SerializeField] private string throwingAnimationName = "RaccoonThrowing";
        [SerializeField] private GameObject shirt;
        [SerializeField] private int shirtsCount;

        private IEnumerator Throwing(StateMachine stateMachine)
        {
            for (int i = 0; i < shirtsCount; i++)
            {
                Instantiate(shirt, GameManager.Player.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }

            ExitState(stateMachine);
        }

        public override void EnterState(StateMachine stateMachine)
        {
            stateMachine.Animator.Play(throwingAnimationName);
            stateMachine.StartCoroutine(Throwing(stateMachine));
        }
        public override void ExitState(StateMachine stateMachine) => stateMachine.StateChoosing();
        public override void UpdateState(StateMachine stateMachine) { }
    }
}