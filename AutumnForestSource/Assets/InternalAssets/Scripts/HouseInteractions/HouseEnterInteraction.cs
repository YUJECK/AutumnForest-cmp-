using AutumnForest.DialogueSystem;
using AutumnForest.Other;
using UnityEngine;

namespace AutumnForest
{
    public class HouseEnterInteraction : MonoBehaviour, IInteractive
    {
        [SerializeField] private Transform housePosition;
        [SerializeField] private DialogueBus familyDialogue;

        private bool dialogueStarted = false;

        public void Detect() { }
        public void DetectionReleased() { }
        public async void Interact()
        {
            await GlobalServiceLocator.GetService<HouseController>().EnterHouse();
         
            if (!dialogueStarted)
            {
                familyDialogue.StartBus();
                dialogueStarted = true;
            }
        }
    }
}