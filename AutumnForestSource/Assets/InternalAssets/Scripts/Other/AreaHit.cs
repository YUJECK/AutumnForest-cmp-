using AutumnForest.Health;
using System;
using UnityEngine;

namespace AutumnForest
{
    public sealed class AreaHit : MonoBehaviour
    {
        public event Action<Collider2D[]> OnHitted;
        [SerializeField] private float attackRange = 0.3f;

        private void OnDrawGizmos() => Gizmos.DrawWireSphere(transform.position, attackRange);

        public void Hit(int damage)
        {
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, attackRange);
            OnHitted?.Invoke(hitObjects);

            foreach (Collider2D obj in hitObjects)
            {
                if (obj.TryGetComponent(out IHealth health))
                    health.TakeHit(damage);
            }
        }
    }
}