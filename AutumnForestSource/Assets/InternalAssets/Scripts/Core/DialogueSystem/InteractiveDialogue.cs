using AutumnForest.Managers;
using AutumnForest.Other;
using UnityEngine;

namespace AutumnForest.DialogueSystem
{
    [RequireComponent(typeof(Dialogue))]
    public class InteractiveDialogue : MonoBehaviour, IInteractive
    {
        private Dialogue dialogue;
        public Dialogue Dialogue
        {
            get
            {
                if (dialogue == null)
                    dialogue = GetComponent<Dialogue>();

                return dialogue;
            }

            private set => dialogue = value;
        }

        private void Awake()
        {
            if (dialogue != null)
                dialogue = GetComponent<Dialogue>();
        }

        public void Detect()
        {
            GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToDialogueCamera(transform);
        }
        public void Interact()
        {
            if (!Dialogue.IsCurrentlyActive) 
                Dialogue.StartDialogue();
        }
        public void DetectionReleased()
        {
            Dialogue.EndDialogue();
            GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToPrevious();
        }
    }
}