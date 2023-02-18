using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon.States
{
    public sealed class RaccoonWaterJetState : StateBehaviour
    {
        private GameObject waterJet;
        private float duration;

        public RaccoonWaterJetState(GameObject waterJet, float duration)
        {
            this.waterJet = waterJet;
            this.duration = duration;
        }

        public override void EnterState(IStateMachineUser stateMachine)
        {
            waterJet.SetActive(true);
            Timer();
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            waterJet.SetActive(false);
        }


        private async void Timer()
        {
            IsCompleted = false;
            await UniTask.Delay(TimeSpan.FromSeconds(duration));
            IsCompleted = true;
        }
    }
}