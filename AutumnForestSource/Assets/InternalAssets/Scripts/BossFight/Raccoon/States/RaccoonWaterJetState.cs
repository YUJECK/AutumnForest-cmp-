using CreaturesAI;
using System.Collections;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public class RaccoonWaterJetState : MonoBehaviour, IState
    {
        [SerializeField] private Transform waterJet;

        public float StateTransitionDelay { get; }

        private IEnumerator StateEnd(StateMachine stateMachine)
        {
            yield return new WaitForSeconds(10f);
            stateMachine.StateChoosing();
        }

        public void EnterState(StateMachine stateMachine)
        {
            waterJet.gameObject.SetActive(true);
            StartCoroutine(StateEnd(stateMachine));
        }

        public void ExitState(StateMachine stateMachine)
        {
            waterJet.gameObject.SetActive(false);
            StopAllCoroutines();
        }

        public void UpdateState(StateMachine stateMachine)
        {
            waterJet.Rotate(0, 0, 0.5f);
        }
    }
}