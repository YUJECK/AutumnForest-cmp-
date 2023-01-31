using AutumnForest.Helpers;
using AutumnForest.StateMachineSystem;
using CreaturesAI.CombatSkills;
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

            IsCompleted = true;
        }
        public override void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            //позже нужно будет сделать какой-нибудь RaccoonAnimationsHelper 
            //и в конструктор этого состояния передавать R..A..H.Throwing
            stateMachine.ServiceLocator.GetService<CreatureAnimator>().PlayAnimation("RaccoonThrowing");
            SpawnCones(stateMachine);
            throwSoundEffect.Play();
        }   
        public override void ExitState(IStateMachineUser stateMachine)
        {
            throwSoundEffect.Stop();
        }

        public override bool CanEnterNewState() => IsCompleted;
    }
}