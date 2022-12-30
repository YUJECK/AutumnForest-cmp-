using CreaturesAI;
using System.Threading.Tasks;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public sealed class RaccoonWaterJetState : State
    {
        private GameObject waterJet;
        private int waterJetStateDuration = 5000;

        public RaccoonWaterJetState(GameObject waterJet, int waterJetStateDuration)
        {
            this.waterJet = waterJet;
            this.waterJetStateDuration = waterJetStateDuration;
        }

        private async void StartWaterJetTimer(IStateMachineUser stateMachine)
        {
            waterJet.SetActive(true);

            await Task.Delay(waterJetStateDuration);

            waterJet.SetActive(false);
            //stateMachine.StateChoosing();
        }
        public override void EnterState(IStateMachineUser stateMachine) => StartWaterJetTimer(stateMachine);
    }
}