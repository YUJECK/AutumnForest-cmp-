using CreaturesAI;
using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    [CreateAssetMenu()]
    public class ConeRoundShootingRaccoonState : State
    {
        [SerializeField] private GameObject cone;
        [SerializeField] private string coneThrowingAnimationName = "RaccoonThrowinng";

        private IEnumerator Shooting(StateMachine stateMachine)
        {
            stateMachine.Shooting.StopPointRotation(true);

            for (int i = 0; i < 10; i++)
            {
                stateMachine.Shooting.Shoot(cone, 10, 0, i*20, ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.5f);
            }

            stateMachine.Shooting.StopPointRotation(false);
            ExitState(stateMachine);
        }

        public override void EnterState(StateMachine stateMachine)
        {
            stateMachine.Animator.Play(coneThrowingAnimationName);
            stateMachine.StartCoroutine(Shooting(stateMachine));
        }
        public override void ExitState(StateMachine stateMachine) => stateMachine.StateChoosing(); 
        public override void UpdateState(StateMachine stateMachine) { }
    }
}