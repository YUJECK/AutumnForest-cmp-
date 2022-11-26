using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class DialogueRaccoonState : State
    {
        public override void EnterState(StateMachine stateMachine)
        {
            stateMachine.Dialogue.StartConversation();
            stateMachine.Dialogue.OnConversationEnds.AddListener(stateMachine.StateChoosing);
        }

        public override void ExitState(StateMachine stateMachine) { }
        public override void UpdateState(StateMachine stateMachine)
        {
            if (Input.GetKeyDown(KeyCode.E))
                stateMachine.Dialogue.NextPhrase();
        }
    }
}