using AutumnForest.Other;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerExitEvent : IInteractive
{
    public List<string> exitTags = new List<string>();
    public UnityEvent OnExit = new UnityEvent();

    public UnityEvent onInteract { get => OnExit; set => OnExit = value; }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (exitTags.Contains(collision.tag))
        {
            OnExit.Invoke();
        }
    }

    public void Interact()
    {

    }
}