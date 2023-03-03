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

            GlobalServiceLocator.GetService<MusicSwitcher>().SwitchToNone();
            dialogue.StartDialogue();

            GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToDialogueCamera(stateMachine.ServiceLocator.GetService<Transform>());
            GlobalServiceLocator.GetService<PlayerMovable>().Disable();
        }
        public override void ExitState(IStateMachineUser stateMachine)
        {
            GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToPrevious();
            GlobalServiceLocator.GetService<MusicSwitcher>().SwitchToBossFightTheme();

            GlobalServiceLocator.GetService<PlayerMovable>().Enable();
            
            GlobalServiceLocator.GetService<BossFightUIMarker>().gameObject.SetActive(true);
            GlobalServiceLocator.GetService<DashHint>().Enable();
        }
    }
}