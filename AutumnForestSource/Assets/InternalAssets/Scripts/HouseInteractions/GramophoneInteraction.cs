using AutumnForest.Other;
using UnityEngine;

namespace AutumnForest
{
    public class GramophoneInteraction : MonoBehaviour, IInteractive
    {
        public void Detect()
        {
        }

        public void DetectionReleased()
        {
        }

        public void Interact()
        {
            GlobalServiceLocator.GetService<MusicSwitcher>().SwitchToGramophone();
        }
    }
}