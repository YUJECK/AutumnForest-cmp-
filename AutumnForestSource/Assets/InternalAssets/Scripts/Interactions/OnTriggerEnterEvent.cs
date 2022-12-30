using AutumnForest.Editor;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.Other
{
    public class OnTriggerEnterEvent : MonoBehaviour
    {
        [SerializeField, Interface(typeof(IInteractive))] private Object interactive;
        private IInteractive Interactive => interactive as IInteractive;
        public List<string> enterTags = new();
        public UnityEvent<GameObject> OnEnter = new();
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (enterTags.Contains(collision.tag))
            {
                OnEnter.Invoke(collision.gameObject);
                Interactive?.Interact();
            }
        }
    }
}