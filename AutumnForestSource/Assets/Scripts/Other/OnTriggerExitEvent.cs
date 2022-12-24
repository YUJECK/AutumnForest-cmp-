using AutumnForest.Other;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerExitEvent : MonoBehaviour
{
    public List<string> exitTags = new List<string>();
    public UnityEvent OnExit = new UnityEvent();

    public UnityEvent<GameObject> onInteract { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (exitTags.Contains(collision.tag))
        {
            OnExit.Invoke();
            Interact();
        }
    }

    public void Interact()
    {

    }
}