using AutumnForest.Health;
using UnityEngine;

namespace AutumnForest.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField, Min(0)] protected int damage;
        [SerializeField] private GameObject collideEffect;
        [SerializeField] private AudioSource hitSoundEffect;

        public Rigidbody2D Rigidbody2D { get; private set; }

        private void Awake()
        {
            if(Rigidbody2D == null)
                Rigidbody2D = GetComponent<Rigidbody2D>();
        }
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