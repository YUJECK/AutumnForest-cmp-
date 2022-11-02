using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnter : MonoBehaviour
{
    public List<string> enterTags = new List<string>();
    public UnityEvent<GameObject> onEnter = new UnityEvent<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enterTags.Contains(collision.tag))
            onEnter.Invoke(collision.gameObject);
    }
}