using AutumnForest.Helpers;
using AutumnForest.Other;
using UnityEngine;
using System;

namespace AutumnForest.DialogueSystem
{
    [RequireComponent(typeof(Dialogue))]
    public class InteractiveDialogue : MonoBehaviour, IInteractive, ICreatureComponent
    {
        public event Action OnInteract;

        public Dialogue Dialogue { get; private set; }

        private void Awake()
        {
            Dialogue = GetComponent<Dialogue>();
        }

        public void Interact()
        {
            if (!Dialogue.IsCurrentlyActive) Dialogue.StartDialogue();
            else Dialogue.NextPhrase();
        }
    }
}