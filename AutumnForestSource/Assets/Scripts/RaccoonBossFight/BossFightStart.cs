using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class BossFightStart : State
    {
        [SerializeField] private float cameraSize;

        public override void EnterState(StateMachine stateMachine)
        {
            GameObject.FindGameObjectWithTag(TagHelper.Log).SetActive(true);
            ServiceLocator.GetService<Camera>().orthographicSize = cameraSize;
            ServiceLocator.GetService<Camera>().GetComponent<MainCameraBrain>().SetTarget(ServiceLocator.GetService<RaccoonStateMachine>().gameObject);

            stateMachine.StateChoosing();
        }

        public override void ExitState(StateMachine stateMachine) { }

        public override void UpdateState(StateMachine stateMachine) { }
    }
}
