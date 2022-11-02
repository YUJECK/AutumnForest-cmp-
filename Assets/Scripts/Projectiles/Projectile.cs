using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool destroy = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
            health.TakeHit(damage);
        
        if(destroy) Destroy(gameObject);
    }
}