using CreaturesAI;
using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonWaterJetState : State
    {
        [SerializeField] private Transform waterJet;

        private IEnumerator StateEnd(StateMachine stateMachine)
        {
            yield return new WaitForSeconds(10f);
            stateMachine.StateChoosing();
        }

        public override void EnterState(StateMachine stateMachine)
        {
            waterJet.gameObject.SetActive(true);
            StartCoroutine(StateEnd(stateMachine));
        }

        public override void ExitState(StateMachine stateMachine)
        {
            waterJet.gameObject.SetActive(false);
        }

        public override void UpdateState(StateMachine stateMachine)
        {
            waterJet.Rotate(0, 0, 0.5f);
        }
    }
}