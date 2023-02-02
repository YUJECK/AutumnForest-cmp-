using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using AutumnForest.Raccoon;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonRoundShotState : StateBehaviour
    {
        private readonly AudioSource throwSoundEffect;

        public RaccoonRoundShotState(AudioSource throwSoundEffect)
        {
            if (throwSoundEffect == null)
                throw new NullReferenceException(nameof(throwSoundEffect));

            this.throwSoundEffect = throwSoundEffect;
        }

        private async UniTask SpawnCones(IStateMachineUser stateMachine)
        {
            throwSoundEffect.Play();
            Shooting shooting = stateMachine.ServiceLocator.GetService<Shooting>();

            //params
            int coneCountPerCycle = 3;
            int cycles = 16;
            int totalCones = coneCountPerCycle * cycles;

            int shotRate = 100; //in milliseconds

            for (int i = 0; i < totalCones; i++)
            {
                await UniTask.Delay(shotRate);
                shooting.ShootWithoutInstantiate(GlobalServiceLocator.GetService<SomePoolsContainer>().ConePool.GetFree().GetComponent<Rigidbody2D>(), 10, 0, ForceMode2D.Impulse);
            }
        }
        public override async void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            {
                stateMachine.ServiceLocator.GetService<CreatureAnimator>().PlayAnimation(RaccoonAnimationsHelper.Throwing);

                stateMachine.ServiceLocator.GetService<Shooting>().TransformRotation.Enable();
                stateMachine.ServiceLocator.GetService<Shooting>().TransformRotation.RotationType = TransformRotation.RotateType.Around;
                stateMachine.ServiceLocator.GetService<Shooting>().TransformRotation.Coefficient = 15;

                await SpawnCones(stateMachine);
            }
            IsCompleted = true;
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            stateMachine.ServiceLocator.GetService<Shooting>().TransformRotation.Disable();
            stateMachine.ServiceLocator.GetService<Shooting>().TransformRotation.Coefficient = 1;
            throwSoundEffect.Stop();
        }
    }
}