using UnityEngine;

namespace AutumnForest.DialogueSystem
{
    public class DialgueBus : MonoBehaviour
    {
        [SerializeField] private Dialogue[] dialogues;
        private int currentDialogue;

        private bool startOnAwake = false;

        private void Start()
        {
            if (startOnAwake)
                StartBus();
        }

        public void StartBus()
        {
            dialogues[0].OnDialogueEnded += Switch;
            dialogues[0].StartDialogue();
        }

        private void Switch(Dialogue dialogue)
        {
            dialogue.OnDialogueEnded -= Switch;
            {
                currentDialogue++;
                if (currentDialogue >= dialogues.Length) return;

                dialogues[currentDialogue].StartDialogue();
            }
            dialogues[currentDialogue].OnDialogueEnded += Switch;
        }
    }
}
