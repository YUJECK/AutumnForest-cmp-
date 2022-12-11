using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterEvent : MonoBehaviour
{
    public List<string> enterTags = new List<string>();
    public UnityEvent<GameObject> OnEnter = new UnityEvent<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enterTags.Contains(collision.tag))
        {
            OnEnter.Invoke(collision.gameObject);
            OnEnterTrigger();
        }
    }
    protected virtual void OnEnterTrigger() { }
}