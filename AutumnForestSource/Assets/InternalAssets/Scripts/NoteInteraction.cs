using AutumnForest.Other;
using UnityEngine;

namespace AutumnForest
{
    public class NoteInteraction : MonoBehaviour, IInteractive
    {
        [SerializeField] private GameObject noteObject;

        public void Detect() { }

        public void DetectionReleased() => noteObject.SetActive(false);

        public void Interact() => noteObject.SetActive(!noteObject.activeSelf);
    }
}
