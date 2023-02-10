using AutumnForest.Other;
using UnityEngine;

namespace AutumnForest
{
    public class HouseExitInteraction : MonoBehaviour, IInteractive
    {
        [SerializeField] private Transform exitPoint;

        public void Detect() { }
        public void DetectionReleased() { }

        public void Interact()
        {
            GlobalServiceLocator.GetService<HouseController>().ExitFromHouse();
        }
    }
}