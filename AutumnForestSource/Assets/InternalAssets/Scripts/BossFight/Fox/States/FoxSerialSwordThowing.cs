using AutumnForest.Helpers;
using AutumnForest.Other;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace AutumnForest.BossFight.Fox.States
{
    public sealed class FoxSerialSwordThowing : StateBehaviour
    {
        private readonly Transform[] swordPoints;
        private readonly Stack<Projectile> pickedSwords = new();

        private readonly PitchedAudio castSoundEffect;

        private readonly float spawnRate = 0.1f;
        private readonly float throwRate = 0.5f;

        private readonly string castAnimationName;

        private CancellationTokenSource cancellationToken;

        public FoxSerialSwordThowing(Transform[] swordPoints, AudioSource castSoundEffect, float spawnRate, float throwRate, string castAnimationName)
        {
            this.swordPoints = swordPoints;

            this.castSoundEffect = new(castSoundEffect);

            this.spawnRate = spawnRate;
            this.throwRate = throwRate;
            this.castAnimationName = castAnimationName;
        }
        ~FoxSerialSwordThowing() => cancellationToken.Dispose();

        public override void EnterState(IStateMachineUser stateMachine)
        {
            cancellationToken = new();
            IsCompleted = false;
            stateMachine.ServiceLocator.GetService<CreatureAnimator>().PlayAnimation(castAnimationName);
            CastPattern(stateMachine.ServiceLocator.GetService<Shooting>()/*, cancellationToken.Token*/);
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            cancellationToken.Cancel();
            cancellationToken.Dispose();

            if (pickedSwords.Count > 0)
            {
                while (pickedSwords.Peek() != null)
                    pickedSwords.Peek().gameObject.SetActive(false);
            }
        }

        private async void CastPattern(Shooting shooting/*, CancellationToken token*/)
        {
            try
            {
                for (int i = 0; i < swordPoints.Length; i++)
                {
                    pickedSwords.Push(SpawnNewSword(swordPoints[i].position));
                    await UniTask.Delay(TimeSpan.FromSeconds(spawnRate)/*, cancellationToken: token*/);
                }
                while (pickedSwords.Count > 0)
                {
                    ThrowSword(shooting, pickedSwords.Peek());

                    pickedSwords.Pop();
                    await UniTask.Delay(TimeSpan.FromSeconds(throwRate)/*, cancellationToken: token*/);
                }
            }
            catch
            {
                IsCompleted = true;
                return;
            }
            IsCompleted = true;
        }
        private Projectile SpawnNewSword(Vector3 swordPosition)
        {
            Projectile sword = GlobalServiceLocator.GetService<SomePoolsContainer>().TargetedSwordPool.GetFree();
            sword.transform.position = swordPosition;

            castSoundEffect.Play();

            return sword;
        }
        private void ThrowSword(Shooting shooting, Projectile sword)
        {
            if (sword.TryGetComponent(out MonoRotator monoRotator))
                monoRotator.TransfromRotation.Disable();

            shooting.ShootWithoutInstantiate(sword.Rigidbody2D, 10, 0, false);

            castSoundEffect.Play();
        }
    }
}