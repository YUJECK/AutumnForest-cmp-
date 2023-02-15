using AutumnForest.Helpers;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;

namespace AutumnForest.BossFight.Raccoon.States
{
    public sealed class RaccoonShirtThrowingState : StateBehaviour
    {
        RaccoonShirtThrowingStateConfig config;

        public RaccoonShirtThrowingState(RaccoonShirtThrowingStateConfig config) => this.config = config;

        public override void EnterState(IStateMachineUser stateMachine) => ThrowShirts(stateMachine);

        private async void ThrowShirts(IStateMachineUser stateMachineUser)
        {
            IsCompleted = false;
            {
                for (int i = 0; i < config.ShirtsCount; i++)
                {
                    ThrowShirt(stateMachineUser);
                    await UniTask.Delay(TimeSpan.FromSeconds(config.ThrowRate));
                }
            }
            IsCompleted = true;
        }
        private void ThrowShirt(IStateMachineUser stateMachineUser)
        {
            Shirt shirt = GlobalServiceLocator.GetService<PoolsContainer>().ShirtPool.GetFree();

            shirt.transform.position = stateMachineUser.ServiceLocator.GetService<SpawnPlace>().GetPosition();
        }
    }
}