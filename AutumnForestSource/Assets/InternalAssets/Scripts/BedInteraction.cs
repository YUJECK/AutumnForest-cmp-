using AutumnForest.Other;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AutumnForest.HouseInteractions
{
    public class BedInteraction : MonoBehaviour, IInteractive
    {
        public void Detect()
        {
        }

        public void DetectionReleased()
        {
        }

        public async void Interact()
        {
            await FindObjectOfType<BlackoutTransition>().StartBlackout();
            SceneManager.LoadScene(2);
        }
    }
}