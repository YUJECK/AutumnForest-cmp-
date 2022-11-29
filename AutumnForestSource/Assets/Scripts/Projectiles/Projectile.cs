using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool destroy = true;
    [SerializeField] private List<string> ignoringTags = new List<string>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!ignoringTags.Contains(collision.collider.tag))
        if (collision.gameObject.TryGetComponent(out Health health))
            health.TakeHit(damage);
        
        if(destroy) Destroy(gameObject);
    }
}