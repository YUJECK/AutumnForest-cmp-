using AutumnForest.BossFight;
using AutumnForest.BossFight.Squirrels;
using AutumnForest.Helpers;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace AutumnForest.Raccoon.States
{
    public sealed class RaccoonSquirrelSpawnState : StateBehaviour
    {
        private MonoObjectPool<Squirrel> squirrelPool;

        private int squirrelMinCount;
        private int squirrelMaxCount;
        private float spawnRate;

        private CancellationTokenSource cancellationToken;

        public RaccoonSquirrelSpawnState(Squirrel squirrelPrefab, int squirrelMinCount, int squirrelMaxCount, float spawnRate)
        {
            squirrelPool = new(squirrelPrefab, GlobalServiceLocator.GetService<ContainerHelper>().CreatureContainer, squirrelMaxCount, true);

            this.squirrelMinCount = squirrelMinCount;
            this.squirrelMaxCount = squirrelMaxCount;
            this.spawnRate = spawnRate;
        }

        public override bool Repeatable() => false;
        public override async void EnterState(IStateMachineUser stateMachine)
        {
            stateMachine.ServiceLocator.GetService<RaccoonAnimator>().PlayIdle();
            cancellationToken = new();

            IsCompleted = false;
            {
                try
                {
                    int squirrelCount = UnityEngine.Random.Range(squirrelMinCount, squirrelMaxCount);

                    for (int i = 0; i < squirrelCount; i++)
                    {
                        squirrelPool.GetFree().transform.position = stateMachine.ServiceLocator.GetService<SpawnPlace>().GetPosition();
                        await UniTask.Delay(TimeSpan.FromSeconds(spawnRate), cancellationToken: cancellationToken.Token);
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
    }
}