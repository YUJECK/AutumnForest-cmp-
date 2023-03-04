using AutumnForest.Other;
using UnityEngine;

namespace AutumnForest
{
    public class NoteInteraction : MonoBehaviour, IInteractive
    {
        [SerializeField] private GameObject noteObject;
        [SerializeField] private AudioSource paperSound;

        public void Detect() { }

        public void DetectionReleased() 
        {
            if(noteObject.activeSelf) paperSound.Play();
            noteObject.SetActive(false);
        }

        public void Interact() 
        {
            noteObject.SetActive(!noteObject.activeSelf);
            paperSound.Play();
        }
    }
}
