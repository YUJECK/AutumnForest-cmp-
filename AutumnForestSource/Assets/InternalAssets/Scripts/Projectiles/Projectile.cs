using CreaturesAI.Health;
using UnityEngine;

namespace AutumnForest.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField, Min(0)] private int damage;
        [SerializeField] private GameObject hitEffect;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IHealth health))
                health.TakeHit(damage);
         
            if(hitEffect != null) Instantiate(hitEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}