using CreaturesAI;
using System.Threading.Tasks;
using UnityEngine;

namespace AutumnForest
{
    public class ClothesThrowingState : State
    {
        [SerializeField] private string throwingAnimationName = "RaccoonThrowing";
        [SerializeField] private int throwingDelay = 1000;
        [SerializeField] private GameObject shirt;
        [SerializeField] private int shirtsCount;

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
            stateMachine.CreatureServiceLocator.GetService<CreatureAnimator>().Play(throwingAnimationName);
            Throwing(stateMachine);
        }
    }
}