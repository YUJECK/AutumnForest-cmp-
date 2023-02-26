using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace AutumnForest.BossFight.Fox.States
{
    public sealed class FoxSwordWandererSpawnState : StateBehaviour
    {
        private const float _enableDelay = 0.25f;
        private const float _spawnRate = 0.8f;
        private const int _swordsCount = 4;

        private CancellationTokenSource cancellationToken;

        public override bool Repeatable() => false;
        public override async void EnterState(IStateMachineUser stateMachine)
        {
            cancellationToken = new();

            IsCompleted = false;
            {
                stateMachine.ServiceLocator.GetService<FoxAnimator>().PlayCasting();
                stateMachine.ServiceLocator.GetService<Shooting>().TransformRotation.Enable();
                stateMachine.ServiceLocator.GetService<Shooting>().TransformRotation.RotationType = TransformRotation.RotateType.ByTarget;

                try
                {
                    for (int i = 0; i < _swordsCount; i++)
                    {
                        await SpawnSword(stateMachine);
                        await UniTask.Delay(TimeSpan.FromSeconds(_spawnRate), cancellationToken: cancellationToken.Token);
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
        public override void ExitState(IStateMachineUser stateMachine)
        {
            cancellationToken.Cancel();
            cancellationToken.Dispose();
        }

        private async UniTask SpawnSword(IStateMachineUser stateMachine)
        {
            SwordWanderer newSwordWanderer = GlobalServiceLocator.GetService<PoolsContainer>().SwordWandererPool.GetFree();
            newSwordWanderer.transform.position = stateMachine.ServiceLocator.GetService<Shooting>().FirePoint.position;
            
            await UniTask.Delay(TimeSpan.FromSeconds(_enableDelay));
            
            stateMachine.ServiceLocator.GetService<FoxSoundsHelper>().CastSound.Play();
            newSwordWanderer.Enable();
        }
    }
}