using AutumnForest.Managers;
using AutumnForest.Other;
using UnityEngine;

namespace AutumnForest
{
    public class HatchInteraction : MonoBehaviour, IInteractive
    {
        [SerializeField] private Transform basementEnterPoint;

        public void Detect()
        {
        }

        public void DetectionReleased()
        {
        }

        public void Interact()
        {
            GlobalServiceLocator.GetService<PlayerMovable>().transform.position = basementEnterPoint.position;
            GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToBasementCamera();
            GlobalServiceLocator.GetService<MusicSwitcher>().SwitchToBasementAmbient();
        }
    }
}