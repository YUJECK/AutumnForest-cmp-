using AutumnForest.Helpers;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace AutumnForest.BossFight.Raccoon.States
{
    public sealed class RaccoonShirtThrowingState : StateBehaviour
    {
        private RaccoonShirtThrowingStateConfig config;
        private CancellationTokenSource cancellationToken;

        public RaccoonShirtThrowingState(RaccoonShirtThrowingStateConfig config) => this.config = config;

        public override void EnterState(IStateMachineUser stateMachine)
        {
            cancellationToken = new();

            ThrowShirts(stateMachine, cancellationToken.Token);
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            cancellationToken.Cancel();
            cancellationToken.Dispose();
        }

        private async void ThrowShirts(IStateMachineUser stateMachineUser, CancellationToken token)
        {
            IsCompleted = false;
            {
                stateMachineUser.ServiceLocator.GetService<RaccoonAnimator>().PlayThrowing();

                try
                {
                    for (int i = 0; i < config.ShirtsCount; i++)
                    {
                        ThrowShirt(stateMachineUser);
                        stateMachineUser.ServiceLocator.GetService<RaccoonSoudsHelper>().ThrowSound.Play();

                        await UniTask.Delay(TimeSpan.FromSeconds(config.ThrowRate), cancellationToken: token);
                    }
                }
                catch
                {
                    IsCompleted = true;
                    return;
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