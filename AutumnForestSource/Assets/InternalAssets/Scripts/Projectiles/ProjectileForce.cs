using UnityEngine;

namespace AutumnForest.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileForce : MonoBehaviour
    {
        [SerializeField] private ForceMode2D forceMode;
        [SerializeField] private float force;
        private new Rigidbody2D rigidbody;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.AddForce(transform.up * force, forceMode);
        }
    }
}