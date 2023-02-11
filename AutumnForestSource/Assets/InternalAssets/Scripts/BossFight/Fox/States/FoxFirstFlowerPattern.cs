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
        private readonly PitchedAudio castSound;

        private CancellationTokenSource cancellationToken;

        public FoxFirstFlowerPattern(Transform[] swordPoints, AudioSource castSound, float shotDelay)
        {
            this.shotDelay = shotDelay;
            this.swordPoints = swordPoints;

            this.castSound = new(castSound);
        }

        public override void EnterState(IStateMachineUser stateMachine)
        {
            cancellationToken = new();
            StartPattern(cancellationToken.Token);
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            cancellationToken.Cancel();
            cancellationToken.Dispose();
        }

        private async void StartPattern(CancellationToken token)
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
                        ThrowSwords(spawnedSwords);
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
        private void ThrowSwords(List<Projectile> spawnedSwords)
        {
            castSound.Play();

            foreach (Projectile sword in spawnedSwords)
                sword.Rigidbody2D.AddForce(sword.transform.up * 10, ForceMode2D.Impulse);
        }
        private Projectile SpawnSword(Transform spawnTransfrom)
        {
            Projectile newSword = GlobalServiceLocator.GetService<SomePoolsContainer>().DefaultSwordPool.GetFree();
            newSword.transform.position = spawnTransfrom.position;
            newSword.transform.rotation = spawnTransfrom.rotation;

            return newSword;
        }
    }
}