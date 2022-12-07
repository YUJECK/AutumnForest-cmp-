using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class DialogueRaccoonState : State
    {
        [SerializeField] private Dialogue dialogue;

        public override void EnterState(StateMachine stateMachine)
        {
            dialogue.StartConversation();
            dialogue.OnConversationEnds.AddListener(stateMachine.StateChoosing);
        }

        public override void ExitState(StateMachine stateMachine) { }
        public override void UpdateState(StateMachine stateMachine)
        {
            if (Input.GetKeyDown(KeyCode.E))
                dialogue.NextPhrase();
        }
    }
}