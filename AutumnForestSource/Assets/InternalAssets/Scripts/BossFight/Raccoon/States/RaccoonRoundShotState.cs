using AutumnForest.Assets.InternalAssets.Scripts;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using CreaturesAI.CombatSkills;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonRoundShotState : StateBehaviour
    {
        private readonly Projectile conePrefab;
        private readonly AudioSource throwSoundEffect;
        private ObjectPool<Projectile> conePool;

        public RaccoonRoundShotState(Projectile conePrefab, Transform coneContainer, AudioSource throwSoundEffect)
        {
            if (conePrefab != null && throwSoundEffect != null && coneContainer != null)
            {
                this.conePrefab = conePrefab;
                this.throwSoundEffect = throwSoundEffect;
            }
            else if (throwSoundEffect == null) throw new NullReferenceException(nameof(throwSoundEffect));
            else if (conePrefab == null) throw new NullReferenceException(nameof(conePrefab));
            else if (coneContainer == null) throw new NullReferenceException(nameof(coneContainer));

            conePool = new(conePrefab, coneContainer, 48, true);
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
                shooting.ShootWithoutInstantiate(conePool.GetFree().GetComponent<Rigidbody2D>(), 10, 0, ForceMode2D.Impulse);
            }

            IsCompleted = true;
        }
        public override void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            //����� ����� ����� ������� �����-������ RaccoonAnimationsHelper 
            //� � ����������� ����� ��������� ���������� R..A..H.Throwing
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