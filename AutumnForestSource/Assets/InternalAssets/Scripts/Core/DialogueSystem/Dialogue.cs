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

        [field: SerializeField] public LocalizatedString DialogueName { get; private set; }
        [field: SerializeField] public LocalizatedString[] DialoguePhrases { get; private set; }

        private void Start() => InitDialogue();

        public void StartDialogue()
        {
            if (!IsCurrentlyActive)
            {
                IsCurrentlyActive = true;

                GlobalServiceLocator.GetService<PlayerInput>().Inputs.Dialogue.performed += InputCallback;

                NextPhrase();
                OnDialogueStarted.Invoke(this);
            }
        }

        public void NextPhrase()
        {
            if (nextPhrase >= DialoguePhrases.Length)
            {
                EndDialogue();
                return;
            }

            OnPhraseChanged.Invoke(DialogueName.Value, DialoguePhrases[nextPhrase].Value);

            nextPhrase++;
        }
        public void EndDialogue()
        {
            if (IsCurrentlyActive)
            {
                nextPhrase = 0;
                IsCurrentlyActive = false;

                GlobalServiceLocator.GetService<PlayerInput>().Inputs.Dialogue.performed -= InputCallback;

                OnDialogueEnded.Invoke(this);
            }
        }

        private void InitDialogue()
        {
            DialogueManager dialogueManager = GlobalServiceLocator.GetService<DialogueManager>();

            if (dialogueManager != null) 
                dialogueManager.AddDialogue(this);
        }

        private void InputCallback(UnityEngine.InputSystem.InputAction.CallbackContext obj) => NextPhrase();
    }
}