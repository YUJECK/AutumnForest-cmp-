using AutumnForest.Other;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerExitEvent : MonoBehaviour
{
    public List<string> exitTags = new();
    public UnityEvent OnExit = new();
    [SerializeField] private IInteractive interactive;

    public IInteractive Interactive { get => interactive; set => interactive = value; }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (exitTags.Contains(collision.tag))
        {
            OnExit.Invoke();
            interactive?.Interact();
        }
    }
}