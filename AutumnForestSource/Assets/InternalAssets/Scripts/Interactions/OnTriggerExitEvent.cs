using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.Other
{
    public class OnTriggerExitEvent : InteractiveHandler
    {
        public List<string> exitTags = new();
        public UnityEvent OnExit = new();

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (exitTags.Contains(collision.tag))
            {
                OnExit.Invoke();
                Interactive?.Interact();
            }
        }
    }
}