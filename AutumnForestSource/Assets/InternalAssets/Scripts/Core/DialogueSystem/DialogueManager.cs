using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest.DialogueSystem
{
    public sealed class DialogueManager
    {
        public event Action<Dialogue> OnDialogueStarted;
        public event Action</*name*/string, /*phrase*/string> OnPhraseSwitched;
        public event Action<Dialogue> OnDialogueEnded;

        private List<Dialogue> dialogues = new();
        private Dialogue currentDialogue;

        public void AddDialogue(Dialogue dialogue)
        {
            dialogues.Add(dialogue);

            dialogue.OnDialogueStarted += OnDialogueStartedCallback;
            dialogue.OnPhraseChanged += OnPhraseChangedCallback;
            dialogue.OnDialogueEnded += OnDialogueEndedCallback;
        }

        private void OnDialogueEndedCallback(Dialogue dialogue)
        {
            currentDialogue = null;
            OnDialogueEnded?.Invoke(dialogue);
        }

        private void OnPhraseChangedCallback(string dialogueName, string dialogueText)
        {
            OnPhraseSwitched?.Invoke(dialogueName, dialogueText);
        }

        private void OnDialogueStartedCallback(Dialogue dialogue)
        {
            if (currentDialogue != dialogue)
            {
                if (currentDialogue != null)
                    currentDialogue.EndDialogue();

                currentDialogue = dialogue;
                OnDialogueStarted?.Invoke(dialogue);
            }
        }
    }
}