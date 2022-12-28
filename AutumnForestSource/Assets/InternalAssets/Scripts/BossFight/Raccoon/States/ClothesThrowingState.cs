using AutumnForest.Player;
using CreaturesAI;
using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    public class ClothesThrowingState : MonoBehaviour, IState
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string throwingAnimationName = "RaccoonThrowing";
        [SerializeField] private float throwingDelay = 1f;
        [SerializeField] private GameObject shirt;
        [SerializeField] private int shirtsCount;

        public float StateTransitionDelay { get; }

        private IEnumerator Throwing(StateMachine stateMachine)
        {
            for (int i = 0; i < shirtsCount; i++)
            {
                Instantiate(shirt, ServiceLocator.GetService<PlayerMovable>().transform.position, Quaternion.identity);
                yield return new WaitForSeconds(throwingDelay);
            }

            stateMachine.StateChoosing();
        }

        public void EnterState(StateMachine stateMachine)
        {
            animator.Play(throwingAnimationName);
            StartCoroutine(Throwing(stateMachine));
        }
        public void ExitState(StateMachine stateMachine) => StopAllCoroutines();
        public void UpdateState(StateMachine stateMachine) { }
    }
}