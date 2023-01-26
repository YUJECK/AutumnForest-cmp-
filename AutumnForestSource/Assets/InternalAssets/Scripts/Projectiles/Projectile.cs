using AutumnForest.Health;
using UnityEngine;

namespace AutumnForest.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField, Min(0)] private int damage;
        [SerializeField] private GameObject collideEffect;
        [SerializeField] private AudioSource hitSoundEffect;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IHealth health))
                health.TakeHit(damage);
         
            if(collideEffect != null) Instantiate(collideEffect, transform.position, transform.rotation);
            if(hitSoundEffect != null) hitSoundEffect.Play();
            gameObject.SetActive(false);
        }
    }
}