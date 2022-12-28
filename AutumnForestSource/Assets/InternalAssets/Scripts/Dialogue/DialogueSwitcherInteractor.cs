using AutumnForest.DialogueSystem;
using AutumnForest.Other;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public class DialogueSwitcherInteractor : MonoBehaviour, IInteractive
    {
        public UnityEvent OnInteract { get; set; } = new();
        [SerializeField] private Dialogue dialogue;

        public void Interact() => dialogue.NextPhrase();
    }
}