using AutumnForest.Health;
using NaughtyAttributes;
using UnityEngine;

namespace AutumnForest.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField, Min(0)] protected int damage;
        [SerializeField] private GameObject collideEffect;
        [SerializeField] private AudioSource hitSoundEffect;

        [SerializeField, Layer] private int projectileLayer;

        public Rigidbody2D Rigidbody2D { get; private set; }

        private void Awake()
        {
            if(Rigidbody2D == null)
                Rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void OnEnable()
        {
            gameObject.layer = projectileLayer;
        }

        public void SpawnCollideffect()
        {
            if (collideEffect != null) 
                Instantiate(collideEffect, transform.position, transform.rotation);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IHealth health))
                health.TakeHit(damage);

            SpawnCollideffect();
            if(hitSoundEffect != null) hitSoundEffect.Play();
            gameObject.SetActive(false);
        }
    }
}