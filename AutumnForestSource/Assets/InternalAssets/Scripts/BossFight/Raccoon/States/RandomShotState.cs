using AutumnForest.BossFight.States;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace AutumnForest.BossFight.Raccoon.States
{
    public sealed partial class RaccoonRandomShotState : StateBehaviour
    {
        private RandomShotStateConfig config;
        private CancellationTokenSource cancellationToken;

        public RaccoonRandomShotState(RandomShotStateConfig config) => this.config = config;

        public override async void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            {
                cancellationToken = new();
                await Shoot(stateMachine, cancellationToken.Token);
            }
            IsCompleted = true;
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            cancellationToken.Cancel();
            cancellationToken.Dispose();
        }

        private async UniTask Shoot(IStateMachineUser stateMachineUser, CancellationToken token)
        {
            stateMachineUser.ServiceLocator.GetService<Shooting>().TransformRotation.RotationType = TransformRotation.RotateType.Around;
            stateMachineUser.ServiceLocator.GetService<Shooting>().TransformRotation.Coefficient = 10;
            
            stateMachineUser.ServiceLocator.GetService<RaccoonAnimator>().PlayThrowing();

            try
            {
                for (int i = 0; i < config.ProjectilesCount; i++)
                {
                    stateMachineUser
                        .ServiceLocator
                        .GetService<Shooting>()
                        .ShootWithInstantiate(config.ProjectilePrefab.Rigidbody2D, config.ProjectileForce, 0);

                    stateMachineUser.ServiceLocator.GetService<RaccoonSoudsHelper>().ThrowSound.Play();

                    await UniTask.Delay(TimeSpan.FromSeconds(UnityEngine.Random.Range(config.ShotMinimumRate, config.ShotMaximumRate)));
                }
            }
            catch
            {
                return;
            }
        }
    }
}