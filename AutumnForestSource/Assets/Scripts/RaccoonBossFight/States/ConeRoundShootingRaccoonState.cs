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
            //Time.timeScale = 0.1f;
            stateMachine.Shooting.StopPointRotation(true);

            for (int i = 0; i < 36; i++)
            {
                stateMachine.Shooting.Shoot(cone, 7, 0, i*30, ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.05f);
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