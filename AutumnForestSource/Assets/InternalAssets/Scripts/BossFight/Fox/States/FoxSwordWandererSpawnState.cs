using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;

namespace AutumnForest.BossFight.Fox.States
{
    public sealed class FoxSwordWandererSpawnState : StateBehaviour
    {
        private const float _enableDelay = 0.25f;
        private const float _spawnRate = 0.8f;
        private const int _swordsCount = 4;

        public override bool Repeatable() => false;
        public override async void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            {
                stateMachine.ServiceLocator.GetService<FoxAnimator>().PlayCasting();
                stateMachine.ServiceLocator.GetService<Shooting>().TransformRotation.Enable();
                stateMachine.ServiceLocator.GetService<Shooting>().TransformRotation.RotationType = TransformRotation.RotateType.ByTarget;

                for (int i = 0; i < _swordsCount; i++)
                {
                    await SpawnSword(stateMachine);
                    await UniTask.Delay(TimeSpan.FromSeconds(_spawnRate));
                }
            }
            IsCompleted = true;
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