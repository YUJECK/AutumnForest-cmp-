using AutumnForest.Health;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public sealed class WaterJet : MonoBehaviour
    {
        [SerializeField] private int damage = 5;

        private void FixedUpdate()
        {
            transform.Rotate(new Vector3(0, 0, 1f));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IHealth health))
                health.TakeHit(damage);
        }
    }
}