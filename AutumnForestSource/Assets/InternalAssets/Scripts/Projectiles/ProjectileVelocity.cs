using UnityEngine;

namespace AutumnForest.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileVelocity : MonoBehaviour
    {
        public Vector2 velocity;
        public float speed = 1;
        private Rigidbody2D rigidbody2D;

        private void Start() => rigidbody2D = GetComponent<Rigidbody2D>();
        private void Update() => rigidbody2D.velocity = velocity * speed;
    }
}