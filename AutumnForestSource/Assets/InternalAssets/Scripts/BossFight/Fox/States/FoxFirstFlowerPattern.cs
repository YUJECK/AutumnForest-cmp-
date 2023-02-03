using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest.BossFight.Fox.States
{
    public sealed class FoxFirstFlowerPattern : StateBehaviour
    {
        private int repeatsCount = 4;
        private Transform[] swordPoints;

        public FoxFirstFlowerPattern(Transform[] swordPoints)
        {
            this.swordPoints = swordPoints;
        }

        public override void EnterState(IStateMachineUser stateMachine)
        {
            StartPattern();
        }

        private async void StartPattern()
        {
            IsCompleted = false;
            {
                for (int i = 0; i < repeatsCount; i++)
                {
                    List<Projectile> spawnedSwords = new();

                    int firstSword;

                    int isEven = i % 2;
                    
                    if (isEven == 0) firstSword = 0;
                    else firstSword = 1;
                    
                    for (int j = firstSword; j < swordPoints.Length; j += 2)
                    {
                        Projectile newSword = GlobalServiceLocator.GetService<SomePoolsContainer>().DefaultSwordPool.GetFree();
                        newSword.transform.position = swordPoints[j].transform.position;
                        newSword.transform.rotation = swordPoints[j].transform.rotation;

                        spawnedSwords.Add(newSword);
                    }

                    await UniTask.Delay(TimeSpan.FromSeconds(2f));

                    foreach (Projectile sword in spawnedSwords)
                        sword.Rigidbody2D.AddForce(sword.transform.up * 10, ForceMode2D.Impulse);
                }
            }
            IsCompleted = true;
        }
    }
}