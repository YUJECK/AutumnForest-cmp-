using AutumnForest.Helpers;
using AutumnForest.Other;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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

        private CancellationTokenSource cancellationToken;

        public FoxSerialSwordThowing(Transform[] swordPoints, AudioSource castSoundEffect, float spawnRate, float throwRate)
        {
            this.swordPoints = swordPoints;

            this.castSoundEffect = new(castSoundEffect);

            this.spawnRate = spawnRate;
            this.throwRate = throwRate;
        }
        ~FoxSerialSwordThowing() => cancellationToken.Dispose();

        public override void EnterState(IStateMachineUser stateMachine)
        {
            cancellationToken = new();
            IsCompleted = false;
            stateMachine.ServiceLocator.GetService<FoxAnimator>().PlayCasting();
            CastPattern(stateMachine.ServiceLocator.GetService<Shooting>(), cancellationToken.Token);
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            cancellationToken.Cancel();

            while (pickedSwords.Count > 0)
                pickedSwords.Pop().gameObject.SetActive(false);
        }

        private async void CastPattern(Shooting shooting, CancellationToken token)
        {
            try
            {
                await SpawningSwords(token);
                await LaunchingSwords(shooting, token);
            }
            catch
            {
                IsCompleted = true;
                return;
            }
            IsCompleted = true;
        }

        private async UniTask SpawningSwords(CancellationToken token)
        {
            for (int i = 0; i < swordPoints.Length; i++)
            {
                pickedSwords.Push(SpawnNewSword(swordPoints[i].position));
                await UniTask.Delay(TimeSpan.FromSeconds(spawnRate), cancellationToken: token);
            }
        }

        private async UniTask LaunchingSwords(Shooting shooting, CancellationToken token)
        {
            while (pickedSwords.Count > 0)
            {
                ThrowSword(shooting, pickedSwords.Peek());

                pickedSwords.Pop();
                await UniTask.Delay(TimeSpan.FromSeconds(throwRate), cancellationToken: token);
            }
        }

        private Projectile SpawnNewSword(Vector3 swordPosition)
        {
            Projectile sword = GlobalServiceLocator.GetService<PoolsContainer>().TargetedSwordPool.GetFree();
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