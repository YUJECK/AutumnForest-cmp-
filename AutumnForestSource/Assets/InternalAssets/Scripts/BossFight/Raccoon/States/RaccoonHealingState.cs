using AutumnForest.Health;
using AutumnForest.Raccoon;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon.States
{
    public sealed class RaccoonHealingState : StateBehaviour
    {
        private CancellationTokenSource cancellationToken;

        private Transform healPosition;
        private Transform defaultPosition;
        private float healRate;
        private int healPoints;

        public override bool Repeatable() => false;

        public RaccoonHealingState(float healRate, int healPoints, Transform healPosition, Transform defaultPosition)
        {
            this.healRate = healRate;
            this.healPoints = healPoints;
            this.healPosition = healPosition;
            this.defaultPosition = defaultPosition;
        }

        public override bool CanExit() => true;

        public override void EnterState(IStateMachineUser stateMachine)
        {
            cancellationToken = new();

            stateMachine.ServiceLocator.GetService<Transform>().position = healPosition.position;
            stateMachine.ServiceLocator.GetService<CreatureAnimator>().PlayAnimation(RaccoonAnimationsHelper.Idle);

            Healing(stateMachine.ServiceLocator.GetService<CreatureHealth>(), cancellationToken.Token);
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            stateMachine.ServiceLocator.GetService<Transform>().position = defaultPosition.position;

            cancellationToken.Cancel();
            cancellationToken.Dispose();
        }

        private async void Healing(IHealth health, CancellationToken token)
        {
            while (true)
            {
                try
                {
                    health.Heal(healPoints);
                    await UniTask.Delay(TimeSpan.FromSeconds(healRate), cancellationToken: token);
                }
                catch
                {
                    return;
                }
            }
        }
    }
}