using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerExit : MonoBehaviour
{
    public List<string> exitTags = new List<string>();
    public UnityEvent<GameObject> onExit = new UnityEvent<GameObject>();

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (exitTags.Contains(collision.tag))
            onExit.Invoke(collision.gameObject);
    }
}