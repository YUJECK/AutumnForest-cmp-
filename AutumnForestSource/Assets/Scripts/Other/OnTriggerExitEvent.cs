using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerExitEvent : MonoBehaviour
{
    public List<string> exitTags = new List<string>();
    public UnityEvent<GameObject> OnExit = new UnityEvent<GameObject>();

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (exitTags.Contains(collision.tag))
            OnExit.Invoke(collision.gameObject);
    }
}