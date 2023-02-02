using AutumnForest.DialogueSystem;
using AutumnForest.Managers;
using AutumnForest.StateMachineSystem;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon.States
{
    public sealed class RaccoonDialogueState : StateBehaviour
    {
        private Dialogue dialogue;

        public RaccoonDialogueState(Dialogue dialogue)
        {
            this.dialogue = dialogue;

            this.dialogue.OnDialogueEnded += OnDialogueEnded;
        }

        private void OnDialogueEnded(Dialogue obj)
        {
            IsCompleted = true;
        }

        ~RaccoonDialogueState()
        {
            this.dialogue.OnDialogueEnded -= OnDialogueEnded;
        }

        public override void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            dialogue.StartDialogue();

            GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToDialogueCamera(stateMachine.ServiceLocator.GetService<Transform>());
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToPrevious();
        }
    }
}