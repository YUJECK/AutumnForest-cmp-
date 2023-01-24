using AutumnForest.Assets.InternalAssets.Scripts;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonRoundShotState : StateBehaviour
    {
        private Projectile conePrefab;
        private ObjectPool<Projectile> conePool;

        private bool nowWork = false;

        public RaccoonRoundShotState(Projectile conePrefab, Transform coneContainer)
        {
            this.conePrefab = conePrefab;
            conePool = new(conePrefab, coneContainer, 48, true);
        }

        private async void SpawnCones()
        {
            //params
            int coneCountPerCycle = 3;
            int cycles = 16;
            int totalCones = coneCountPerCycle * cycles;

            int shotRate = 100; //in milliseconds

            for (int i = 0; i < totalCones; i++)
            {
                Debug.Log(i);
                await UniTask.Delay(shotRate);
                //async cycle shooting
            }

            IsCompleted = true;
        }
        public override void EnterState(IStateMachineUser stateMachine)
        {
            Debug.Log("asdasd");

            SpawnCones();
        }

        public override bool CanEnterNewState() => IsCompleted;
    }
}