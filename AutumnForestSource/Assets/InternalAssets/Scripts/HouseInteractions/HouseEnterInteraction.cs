using AutumnForest.DialogueSystem;
using AutumnForest.Managers;
using AutumnForest.Other;
using UnityEngine;

namespace AutumnForest
{
    public class HouseEnterInteraction : MonoBehaviour, IInteractive
    {
        [SerializeField] private Transform housePosition;
        [SerializeField] private Dialogue familyDialogue;

        public void Detect() { }
        public void DetectionReleased() { }
        public void Interact()
        {
            FindObjectOfType<BlackoutTransition>().StartBlackout();

            GlobalServiceLocator.GetService<PlayerMovable>().transform.position = housePosition.position;
            GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToHouseCamera();

            familyDialogue.StartDialogue();
        }
    }
}