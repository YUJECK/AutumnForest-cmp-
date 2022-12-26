using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.Other
{
    public class OnTriggerEnterEvent : InteractiveHandler
    {
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