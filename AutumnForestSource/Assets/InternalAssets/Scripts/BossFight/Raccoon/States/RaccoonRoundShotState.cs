using AutumnForest.BossFight.Raccoon;
using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonRoundShotState : StateBehaviour
    {
        private CancellationTokenSource cancellationToken;
        private RaccoonRoundShotStateConfig config;

        public RaccoonRoundShotState(RaccoonRoundShotStateConfig config) => this.config = CheckForNullHelper.Check(config, nameof(config));

        public override async void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            {
                cancellationToken = new();
                stateMachine.ServiceLocator.GetService<RaccoonAnimator>().PlayThrowing();

                InitTransformRotation(stateMachine.ServiceLocator.GetService<Shooting>().TransformRotation);

                await SpawnCones(stateMachine, cancellationToken.Token);
            }
            IsCompleted = true;
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            ResetTransfomRotation(stateMachine.ServiceLocator.GetService<Shooting>().TransformRotation);
            stateMachine.ServiceLocator.GetService<RaccoonSoudsHelper>().LoopedThrowSound.Stop();

            cancellationToken.Cancel();
            cancellationToken.Dispose();
        }

        private async UniTask SpawnCones(IStateMachineUser stateMachine, CancellationToken token)
        {
            stateMachine.ServiceLocator.GetService<RaccoonSoudsHelper>().LoopedThrowSound.Play();
            Shooting shooting = stateMachine.ServiceLocator.GetService<Shooting>();

            try
            {
                for (int i = 0; i < config.TotalConeCount; i++)
                {
                    await UniTask.Delay(config.ThrowRate, cancellationToken: token);
                    shooting.ShootWithoutInstantiate(GlobalServiceLocator.GetService<PoolsContainer>().ConePool.GetFree().GetComponent<Rigidbody2D>(), 8, 0, true, ForceMode2D.Impulse);
                }
            }
            catch
            {
                return;
            }
        }
        private void ResetTransfomRotation(TransformRotation transformRotation)
        {
            transformRotation.Disable();
            transformRotation.Coefficient = 1;
        }
        private void InitTransformRotation(TransformRotation transformRotation)
        {
            transformRotation.Enable();
            transformRotation.RotationType = TransformRotation.RotateType.Around;
            transformRotation.Coefficient = 15;
        }
    }
}