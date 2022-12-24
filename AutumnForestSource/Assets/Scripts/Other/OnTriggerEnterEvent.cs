using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.Other
{
    public class OnTriggerEnterEvent : MonoBehaviour
    {
        //fields
        public List<string> enterTags = new();
        public UnityEvent<GameObject> OnEnter = new();
        private IInteractive interactive;

        //getters
        public IInteractive Interactive { get => interactive; set => interactive = value; }
        
        //unity methods
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (enterTags.Contains(collision.tag))
            {
                OnEnter.Invoke(collision.gameObject);
                if (interactive != null) interactive.Interact();
            }
        }
    }
}