using CreaturesAI;
using UnityEngine;
using AutumnForest.DialogueSystem;

namespace AutumnForest.BossFight.Raccoon
{
    public class DialogueRaccoonState : MonoBehaviour, IState
    {
        [SerializeField] private Dialogue dialogue;
        public float StateTransitionDelay { get; }

        public void EnterState(StateMachine stateMachine)
        {
            dialogue.StartConversation();
            dialogue.OnConversationEnds.AddListener(stateMachine.StateChoosing);
        }

        public void ExitState(StateMachine stateMachine) { dialogue.OnConversationEnds.RemoveListener(stateMachine.StateChoosing); }
        public void UpdateState(StateMachine stateMachine)
        {
            if (Input.GetKeyDown(KeyCode.E))
                dialogue.NextPhrase();
        }
    }
}