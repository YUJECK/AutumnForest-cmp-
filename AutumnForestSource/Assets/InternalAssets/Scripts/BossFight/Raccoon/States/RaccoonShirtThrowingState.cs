using AutumnForest.Helpers;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon.States
{
    public sealed class RaccoonShirtThrowingState : StateBehaviour
    {
        private RaccoonShirtThrowingStateConfig config;
        private PitchedAudio throwAudio;

        public RaccoonShirtThrowingState(RaccoonShirtThrowingStateConfig config, AudioSource throwAudio)
        {
            this.config = config;
            this.throwAudio = new(throwAudio);
        }

        public override void EnterState(IStateMachineUser stateMachine) => ThrowShirts(stateMachine);

        private async void ThrowShirts(IStateMachineUser stateMachineUser)
        {
            IsCompleted = false;
            {
                stateMachineUser.ServiceLocator.GetService<RaccoonAnimator>().PlayThrowing();

                for (int i = 0; i < config.ShirtsCount; i++)
                {
                    ThrowShirt(stateMachineUser);
                    throwAudio.Play();
                    await UniTask.Delay(TimeSpan.FromSeconds(config.ThrowRate));
                }
            }
            IsCompleted = true;
        }
        private void ThrowShirt(IStateMachineUser stateMachineUser)
        {
            Shirt shirt = GlobalServiceLocator.GetService<PoolsContainer>().ShirtPool.GetFree();

            shirt.transform.position = GlobalServiceLocator.GetService<PlayerMovable>().transform.position;
        }
    }
}