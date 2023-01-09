using System;
using System.Collections.Generic;

namespace AutumnForest.DialogueSystem
{
    public sealed class DialogueManager
    {
        public event Action<Dialogue> OnDialogueStarted;
        public event Action</*name*/string, /*phrase*/string> OnPhraseSwitched;
        public event Action<Dialogue> OnDialogueEnded;

        private List<Dialogue> dialogues = new();

        public void AddDialogue(Dialogue dialogue)
        {
            dialogues.Add(dialogue);

            dialogue.OnDialogueStarted += OnDialogueStartedCallback;
            dialogue.OnPhraseChanged += OnPhraseChangedCallback;
            dialogue.OnDialogueEnded += OnDialogueEndedCallback;
        }

        private void OnDialogueEndedCallback(Dialogue dialogue)
        {
            OnDialogueStarted?.Invoke(dialogue);
        }

        private void OnPhraseChangedCallback(string dialogueName, string dialogueText)
        {
            OnPhraseSwitched?.Invoke(dialogueName, dialogueText);
        }

        private void OnDialogueStartedCallback(Dialogue dialogue)
        {
            OnDialogueEnded?.Invoke(dialogue);
        }
    }
}