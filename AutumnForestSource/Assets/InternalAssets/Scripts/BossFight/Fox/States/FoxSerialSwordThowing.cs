using AutumnForest.Helpers;
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
        private Transform[] swordPoints;
        private Stack<Projectile> pickedSwords = new();

        public FoxSerialSwordThowing(Transform[] swordPoints)
        {
            this.swordPoints = swordPoints;
        }

        public override async void EnterState(IStateMachineUser stateMachine)
        {
            for (int i = 0; i < swordPoints.Length; i++)
            {
                Projectile sword = GlobalServiceLocator.GetService<SomePoolsContainer>().TargetedSwordPool.GetFree();
                sword.transform.position = swordPoints[i].position;
                pickedSwords.Push(sword);

                await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
            }
            while (pickedSwords.Count != 0)
            {
                if (pickedSwords.Peek() != null)
                     stateMachine.ServiceLocator.GetService<Shooting>().ShootWithoutInstantiate(pickedSwords.Peek().Rigidbody2D, 10, 0, false);
                
                pickedSwords.Pop();
                await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            }
        }

        public override void ExitState(IStateMachineUser stateMachine)
        {
            if(pickedSwords.Count > 0)
            {
                while (pickedSwords.Peek() != null)
                    pickedSwords.Peek().gameObject.SetActive(false);
            }
        }
    }
}