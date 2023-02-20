using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace AutumnForest.BossFight.Fox.States
    
{
    public sealed class FoxFirstFlowerPattern : StateBehaviour
    {
        private readonly float shotDelay = 2f;
        private readonly int repeatsCount = 4;
        private readonly Transform[] swordPoints;

        private CancellationTokenSource cancellationToken;

        public FoxFirstFlowerPattern(Transform[] swordPoints, float shotDelay)
        {
            this.shotDelay = shotDelay;
            this.swordPoints = swordPoints;
        }
        ~FoxFirstFlowerPattern() => cancellationToken.Dispose();

        public override void EnterState(IStateMachineUser stateMachine)
        {
            cancellationToken = new();
            stateMachine.ServiceLocator.GetService<FoxAnimator>().PlayCasting();
            StartPattern(cancellationToken.Token, stateMachine.ServiceLocator.GetService<FoxSoundsHelper>().CastSound);
        }
        public override void ExitState(IStateMachineUser stateMachine) => cancellationToken.Cancel();

        private async void StartPattern(CancellationToken token, PitchedAudio castAudio)
        {
            IsCompleted = false;
            {
                List<Projectile> spawnedSwords = new();

                try
                {
                    for (int i = 0; i < repeatsCount; i++)
                    {
                        for (int j = FirstSwordIndex(i); j < swordPoints.Length; j += 2)
                            spawnedSwords.Add(SpawnSword(swordPoints[j]));

                        await UniTask.Delay(TimeSpan.FromSeconds(shotDelay), cancellationToken: token);
                        ThrowSwords(spawnedSwords, castAudio);
                    }
                }
                catch
                {
                    IsCompleted = true;

                    foreach (Projectile item in spawnedSwords)
                        item.gameObject.SetActive(false);

                    return;
                }
            }
            IsCompleted = true;
        }

        private int FirstSwordIndex(int cycleIndex)
        {
            int isEven = cycleIndex % 2;

            if (isEven == 0) return 0;
            else return 1;
        }
        private void ThrowSwords(List<Projectile> spawnedSwords, PitchedAudio castAudio)
        {
            castAudio.Play();
            
            foreach (Projectile sword in spawnedSwords)
                sword.Rigidbody2D.AddForce(sword.transform.up * 10, ForceMode2D.Impulse);
        }
        private Projectile SpawnSword(Transform spawnTransfrom)
        {
            Projectile newSword = GlobalServiceLocator.GetService<PoolsContainer>().DefaultSwordPool.GetFree();
            newSword.transform.position = spawnTransfrom.position;
            newSword.transform.rotation = spawnTransfrom.rotation;

            return newSword;
        }
    }
}