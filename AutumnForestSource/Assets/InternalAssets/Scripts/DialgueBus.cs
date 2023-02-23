using System;
using UnityEngine;

namespace AutumnForest.DialogueSystem
{
    public class DialgueBus : MonoBehaviour
    {
        [SerializeField] private Dialogue[] dialogues;
        private int currentDialogue;

        private bool startOnAwake = false;

        public event Action OnBusStarted;
        public event Action OnBusCompleted;

        private void Start()
        {
            if (startOnAwake)
                StartBus();
        }

        public void StartBus()
        {
            dialogues[0].OnDialogueEnded += Switch;
            dialogues[0].StartDialogue();

            OnBusStarted?.Invoke();
        }

        private void Switch(Dialogue dialogue)
        {
            dialogue.OnDialogueEnded -= Switch;
            {
                currentDialogue++;
                if (currentDialogue >= dialogues.Length)
                {
                    OnBusCompleted?.Invoke();
                    return;
                }

                dialogues[currentDialogue]?.StartDialogue();
            }
            dialogues[currentDialogue].OnDialogueEnded += Switch;
        }
    }
}
