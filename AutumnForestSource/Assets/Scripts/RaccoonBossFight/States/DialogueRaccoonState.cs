using CreaturesAI;

namespace AutumnForest
{
    public class DialogueRaccoonState : State
    {
        public override void EnterState(StateMachine stateMachine)
        {
            stateMachine.Dialogue.StartConversation();
            stateMachine.Dialogue.onConversationEnds.AddListener(stateMachine.StateChoosing);
        }

        public override void ExitState(StateMachine stateMachine) { }
        public override void UpdateState(StateMachine stateMachine) { }
    }
}