using AutumnForest.Helpers;
using System;
using UnityEngine;

namespace AutumnForest.DialogueSystem
{
    public sealed class Dialogue : MonoBehaviour
    {
        private int nextPhrase = 0;

        public event Action<Dialogue> OnDialogueStarted;
        public event Action</*name*/string, /*phrase*/string> OnPhraseChanged;
        public event Action<Dialogue> OnDialogueEnded;

        public bool IsCurrentlyActive { get; private set; } = false;

        [SerializeField] public string dialogueName = "Somebody";
        [SerializeField, TextArea(2, 20)] public string[] dialoguePhrases;

        private void Start() => InitDialogue();

        public void StartDialogue()
        {
            if(!IsCurrentlyActive)
            {
                OnDialogueStarted.Invoke(this);
                IsCurrentlyActive = true;

                NextPhrase();
            }
        }
        public void NextPhrase()
        {
            if (nextPhrase >= dialoguePhrases.Length)
            {
                EndDialogue();
                return;
            }

            OnPhraseChanged.Invoke(dialogueName, dialoguePhrases[nextPhrase]);

            nextPhrase++;
        }
        public void EndDialogue()
        {
            if(IsCurrentlyActive)
            {
                nextPhrase = 0;
                IsCurrentlyActive = false;

                OnDialogueEnded.Invoke(this);
            }
        }

        private void InitDialogue()
        {
            DialogueManager dialogueManager = GlobalServiceLocator.GetService<DialogueManager>();

            if (dialogueManager != null)
                dialogueManager.AddDialogue(this);
            else
                throw new NullReferenceException(nameof(dialogueManager));
        }
    }
}