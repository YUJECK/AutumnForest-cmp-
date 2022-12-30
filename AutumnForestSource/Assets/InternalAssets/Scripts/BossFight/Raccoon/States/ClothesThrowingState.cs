using CreaturesAI;
using System.Threading.Tasks;
using UnityEngine;

namespace AutumnForest
{
    public class ClothesThrowingState : State
    {
        private Animator animator;
        private string throwingAnimationName = "RaccoonThrowing";
        private int throwingDelay = 1000;
        private GameObject shirt;
        private int shirtsCount;

        private async void Throwing(IStateMachineUser stateMachine)
        {
            for (int i = 0; i < shirtsCount; i++)
            {
                GameObject.Instantiate(shirt, GlobalServiceLocator.GetService<PlayerMovable>().transform.position, Quaternion.identity);
                await Task.Delay(throwingDelay);
            }

            stateMachine.StateChoosing();
        }

        public override void EnterState(IStateMachineUser stateMachine)
        {
            animator.Play(throwingAnimationName);
            Throwing(stateMachine);
        }
    }
}