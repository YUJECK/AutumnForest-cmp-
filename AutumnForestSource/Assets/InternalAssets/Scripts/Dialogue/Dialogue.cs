using AutumnForest.Helpers;
using AutumnForest.Other;
using System;
using UnityEngine;

namespace AutumnForest.DialogueSystem
{
    public class Dialogue : MonoBehaviour, IInteractive, ICreatureComponent
    {
        private int nextPhrase = 0;

        public event Action<Dialogue> OnDialogueStarted;
        public event Action</*name*/string, /*phrase*/string> OnPhraseChanged;
        public event Action<Dialogue> OnDialogueEnded;

        public event Action OnInteract;

        public bool IsCurrentlyActive { get; private set; } = false;

        [SerializeField] public string dialogueName = "Somebody";
        [SerializeField, TextArea(2, 20)] public string[] dialoguePhrases;


        private void Start()
        {
            InitDialogue();
        }

        private void StartDialogue()
        {
            OnDialogueStarted.Invoke(this);
            IsCurrentlyActive = true;
        }
        private void NextPhrase()
        {
            if (nextPhrase >= dialoguePhrases.Length)
            {
                EndDialogue();
                return;
            }

            OnPhraseChanged.Invoke(dialogueName, dialoguePhrases[nextPhrase]);
            
            nextPhrase++;
        }
        private void EndDialogue()
        {
            nextPhrase = 0;
            IsCurrentlyActive = false;

            OnDialogueEnded.Invoke(this);
        }

        private void InitDialogue()
        {
            DialogueManager dialogueManager = GlobalServiceLocator.GetService<DialogueManager>();

            if (dialogueManager != null)
                dialogueManager.AddDialogue(this);
            else
                throw new NullReferenceException(nameof(dialogueManager));
        }

        public void Interact()
        {
            if (!IsCurrentlyActive) StartDialogue();
            else NextPhrase();
        }
    }
}