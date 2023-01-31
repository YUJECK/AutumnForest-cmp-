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

        private async void SpawnCones(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            {
                throwSoundEffect.Play();
                Shooting shooting = stateMachine.ServiceLocator.GetService<Shooting>();

                //params
                int coneCountPerCycle = 3;
                int cycles = 16;
                int totalCones = coneCountPerCycle * cycles;

                int shotRate = 100; //in milliseconds

                shooting.TransformRotation.RotationType = TransformRotation.RotateType.Around;

                for (int i = 0; i < totalCones; i++)
                {
                    await UniTask.Delay(shotRate);
                    shooting.ShootWithoutInstantiate(GlobalServiceLocator.GetService<SomePoolsContainer>().ConePool.GetFree().GetComponent<Rigidbody2D>(), 10, 0, ForceMode2D.Impulse);
                }
            }

            IsCompleted = true;
        }
        public override void EnterState(IStateMachineUser stateMachine)
        {
            stateMachine.ServiceLocator.GetService<CreatureAnimator>().PlayAnimation(RaccoonAnimationsHelper.Throwing);

            SpawnCones(stateMachine);
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            throwSoundEffect.Stop();
        }

        public override bool CanEnterNewState() => IsCompleted;
    }
}