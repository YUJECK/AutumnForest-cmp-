using AutumnForest.DialogueSystem;
using AutumnForest.Managers;
using AutumnForest.Other;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest
{
    public class TrapdoorInteraction : MonoBehaviour, IInteractive, IDisablable
    {
        [SerializeField] private Transform basementEnterPoint;
        [SerializeField] private List<Dialogue> interactTrysDialogues;

        public bool Enabled { get; private set; } = false;

        public event Action OnEnabled;
        public event Action OnDisabled;

        public void Detect() { }
        public void DetectionReleased() { }
        public void Interact()
        {
            if (interactTrysDialogues.Count > 0 && !interactTrysDialogues[0].IsCurrentlyActive)
                StartNextDialogue();
            else if(interactTrysDialogues.Count == 0) 
                EnterToBasement();
        }

        public void Enable() => Enabled = true;
        public void Disable() => Enabled = false;

        private void StartNextDialogue()
        {
            interactTrysDialogues[0].StartDialogue();
            interactTrysDialogues[0].OnDialogueEnded += OnDialogueEnded;
        }

        private void OnDialogueEnded(Dialogue dialogue)
        {
            dialogue.OnDialogueEnded -= OnDialogueEnded;
            interactTrysDialogues.Remove(dialogue);
        }
        private void EnterToBasement()
        {
            GlobalServiceLocator.GetService<PlayerMovable>().transform.position = basementEnterPoint.position;

            GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToBasementCamera();
            GlobalServiceLocator.GetService<MusicSwitcher>().SwitchToBasementAmbient();
        }

    }
}