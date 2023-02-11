using AutumnForest.Helpers;
using AutumnForest.Other;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
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

        public FoxSerialSwordThowing(Transform[] swordPoints, AudioSource castSoundEffect, float spawnRate, float throwRate)
        {
            this.swordPoints = swordPoints;

            this.castSoundEffect = new(castSoundEffect);

            this.spawnRate = spawnRate;
            this.throwRate = throwRate;
        }

        public override async void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            {
                for (int i = 0; i < swordPoints.Length; i++)
                {
                    pickedSwords.Push(SpawnNewSword(swordPoints[i].position));
                    await UniTask.Delay(TimeSpan.FromSeconds(spawnRate));
                }
                while (pickedSwords.Count > 0)
                {
                    ThrowSword(stateMachine, pickedSwords.Peek());

                    pickedSwords.Pop();
                    await UniTask.Delay(TimeSpan.FromSeconds(throwRate));
                }
            }
            IsCompleted = true;
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            if(pickedSwords.Count > 0)
            {
                while (pickedSwords.Peek() != null)
                    pickedSwords.Peek().gameObject.SetActive(false);
            }
        }
        
        private Projectile SpawnNewSword(Vector3 swordPosition)
        {
            Projectile sword = GlobalServiceLocator.GetService<SomePoolsContainer>().TargetedSwordPool.GetFree();
            sword.transform.position = swordPosition;

            castSoundEffect.Play();

            return sword;
        }
        private void ThrowSword(IStateMachineUser stateMachine, Projectile sword)
        {
            if (sword.TryGetComponent(out MonoRotator monoRotator))
                monoRotator.TransfromRotation.Disable();

            stateMachine.ServiceLocator.GetService<Shooting>().ShootWithoutInstantiate(sword.Rigidbody2D, 10, 0, false);

            castSoundEffect.Play();
        }
    }
}