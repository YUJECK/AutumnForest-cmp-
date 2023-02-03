using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Fox.States
{
    public sealed class FoxTurnedRoundSwordThrowingState : StateBehaviour
    {
        private float swordForce = 15;
        private float shotRate = 0.3f;

        private Transform[] swordPoits;

        public FoxTurnedRoundSwordThrowingState(float shotRate, float swordForce, Transform[] swordPoits)
        {
            this.shotRate = shotRate;
            this.swordForce = swordForce;
            this.swordPoits = swordPoits;
        }

        public override async void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            {
                for (int i = 0; i < swordPoits.Length; i++)
                {
                    Projectile nextSword = GlobalServiceLocator.GetService<SomePoolsContainer>().DefaultSwordPool.GetFree();

                    nextSword.transform.position = swordPoits[i].transform.position;
                    nextSword.transform.rotation = swordPoits[i].transform.rotation;

                    nextSword.Rigidbody2D.AddForce(nextSword.transform.up* swordForce, ForceMode2D.Impulse);

                    await UniTask.Delay(TimeSpan.FromSeconds(shotRate));
                }
            }
            IsCompleted = true;
        }
    }
}