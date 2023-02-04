using AutumnForest.Managers;
using AutumnForest.Other;
using UnityEngine;

namespace AutumnForest
{
    public class LadderInteraction : MonoBehaviour, IInteractive
    {
        [SerializeField] private Transform hatchPoint;

        public void Detect()
        {
        }

        public void DetectionReleased()
        {
        }

        public void Interact()
        {
            GlobalServiceLocator.GetService<PlayerMovable>().transform.position = hatchPoint.position;
            GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToHouseCamera();
            GlobalServiceLocator.GetService<MusicSwitcher>().SwitchToMainTheme();
        }
    }
}