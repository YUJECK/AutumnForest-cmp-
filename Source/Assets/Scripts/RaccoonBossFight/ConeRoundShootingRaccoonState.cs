using CreaturesAI;
using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    public class ConeRoundShootingRaccoonState : State
    {
        [SerializeField] private GameObject cone;
        [SerializeField] private string coneThrowingAnimationName = "RaccoonThrowinng";

        private IEnumerator Shooting(StateMachine stateMachine)
        {
            stateMachine.Shooting.StopPointRotation(true);

            for (int i = 0; i < 10; i++)
            {
                stateMachine.Shooting.Shoot(cone, 15, 0, i*30, ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.1f);
            }

            stateMachine.Shooting.StopPointRotation(false);
            stateMachine.StateChoosing();
        }

        public override void EnterState(StateMachine stateMachine)
        {
            stateMachine.Animator.Play(coneThrowingAnimationName);
            StartCoroutine(Shooting(stateMachine));
        }
        public override void ExitState(StateMachine stateMachine) => StopAllCoroutines(); 
        public override void UpdateState(StateMachine stateMachine) { }
    }
}