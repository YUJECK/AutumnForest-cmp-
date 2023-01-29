using AutumnForest.BossFight;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest.Raccoon.States
{
    public sealed class RaccoonSquirrelSpawnState : StateBehaviour
    {
        //в будущем нужно добавить пулл для этого

        private GameObject squirrelPrefab;

        private int squirrelMinCount;
        private int squirrelMaxCount;
        private float spawnRate;

        public RaccoonSquirrelSpawnState(GameObject squirrelPrefab, int squirrelMinCount, int squirrelMaxCount, float spawnRate)
        {
            this.squirrelPrefab = squirrelPrefab;

            this.squirrelMinCount = squirrelMinCount;
            this.squirrelMaxCount = squirrelMaxCount;
            this.spawnRate = spawnRate;
        }

        public override async void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;

            int squirrelCount = UnityEngine.Random.Range(squirrelMinCount, squirrelMaxCount);

            for (int i = 0; i < squirrelCount; i++)
            {
                GameObject.Instantiate(squirrelPrefab, stateMachine.ServiceLocator.GetService<SpawnPlace>().GetPosition(), Quaternion.identity);
                await UniTask.Delay(TimeSpan.FromSeconds(spawnRate));
            }

            IsCompleted = true;
        }

        public override bool CanEnterNewState() => IsCompleted;
    }
}