using AutumnForest.Managers;
using AutumnForest.Other;
using UnityEngine;

namespace AutumnForest
{
    public class HouseInteraction : MonoBehaviour, IInteractive
    {
        [SerializeField] private Transform housePosition;

        public void Detect()
        {
        }

        public void DetectionReleased()
        {
        }

        public void Interact()
        {
            GlobalServiceLocator.GetService<PlayerMovable>().transform.position = housePosition.position;
            GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToHouseCamera();
        }
    }
}