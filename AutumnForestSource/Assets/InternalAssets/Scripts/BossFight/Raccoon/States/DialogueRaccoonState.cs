using CreaturesAI;
using UnityEngine;
using AutumnForest.DialogueSystem;

namespace AutumnForest.BossFight.Raccoon
{
    public class DialogueRaccoonState : State
    {
        [SerializeField] private Dialogue dialogue;

        public override void EnterState(IStateMachineUser stateMachine)
        {
            dialogue.StartConversation();
            dialogue.OnConversationEnds.AddListener(stateMachine.StateChoosing);
        }

        public override void ExitState(IStateMachineUser stateMachine) { dialogue.OnConversationEnds.RemoveListener(stateMachine.StateChoosing); }
        public override void UpdateState(IStateMachineUser stateMachine)
        {
            if (Input.GetKeyDown(KeyCode.E))
                dialogue.NextPhrase();
        }
    }
}