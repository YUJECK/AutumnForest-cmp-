using AutumnForest.Helpers;
using AutumnForest.Other;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEditorInternal;
using UnityEngine;

namespace AutumnForest.BossFight.Fox.States
{
    public sealed class FoxSerialSwordThowing : StateBehaviour
    {
        private readonly Transform[] swordPoints;
        private readonly Stack<Projectile> pickedSwords = new();

        private readonly float spawnRate = 0.1f;
        private readonly float throwRate = 0.5f;

        private CancellationTokenSource cancellationToken;

        public FoxSerialSwordThowing(Transform[] swordPoints, float spawnRate, float throwRate)
        {
            this.swordPoints = swordPoints;

            this.spawnRate = spawnRate;
            this.throwRate = throwRate;
        }
        ~FoxSerialSwordThowing() => cancellationToken.Dispose();

        public override void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            cancellationToken = new();
            
            stateMachine.ServiceLocator.GetService<FoxAnimator>().PlayCasting();
            CastPattern(stateMachine.ServiceLocator.GetService<Shooting>(), stateMachine.ServiceLocator.GetService<FoxSoundsHelper>().CastSound, cancellationToken.Token);
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            cancellationToken.Cancel();

            while (pickedSwords.Count > 0)
                pickedSwords.Pop().gameObject.SetActive(false);
        }

        private async void CastPattern(Shooting shooting, PitchedAudio castSound, CancellationToken token)
        {
            try
            {
                await SpawningSwords(castSound, token);
                await LaunchingSwords(shooting, castSound, token);
            }
            catch
            {
                IsCompleted = true;
                return;
            }
            IsCompleted = true;
        }

        private async UniTask SpawningSwords(PitchedAudio castSound, CancellationToken token)
        {
            for (int i = 0; i < swordPoints.Length; i++)
            {
                pickedSwords.Push(SpawnNewSword(swordPoints[i].position, castSound));
                await UniTask.Delay(TimeSpan.FromSeconds(spawnRate), cancellationToken: token);
            }
        }

        private async UniTask LaunchingSwords(Shooting shooting, PitchedAudio castSound, CancellationToken token)
        {
            while (pickedSwords.Count > 0)
            {
                ThrowSword(shooting, pickedSwords.Peek(), castSound);

                pickedSwords.Pop();
                await UniTask.Delay(TimeSpan.FromSeconds(throwRate), cancellationToken: token);
            }
        }

        private Projectile SpawnNewSword(Vector3 swordPosition, PitchedAudio castSound)
        {
            Projectile sword = GlobalServiceLocator.GetService<PoolsContainer>().TargetedSwordPool.GetFree();
            sword.transform.position = swordPosition;

            castSound.Play();

            return sword;
        }
        private void ThrowSword(Shooting shooting, Projectile sword, PitchedAudio castSound)
        {
            if (sword.TryGetComponent(out MonoRotator monoRotator))
                monoRotator.TransfromRotation.Disable();

            shooting.ShootWithoutInstantiate(sword.Rigidbody2D, 10, 0, false);

            castSound.Play();
        }
    }
}