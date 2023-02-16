using AutumnForest.Health;
using System;
using UnityEngine;

namespace AutumnForest
{
    public sealed class AreaHit : MonoBehaviour
    {
        public event Action OnHitted;
        [SerializeField] private float attackRange = 0.3f;

        private void OnDrawGizmos() => Gizmos.DrawWireSphere(transform.position, attackRange);

        public void Hit(int damage)
        {
            Collider2D[] hitObj = Physics2D.OverlapCircleAll(transform.position, attackRange);
            OnHitted?.Invoke();

            foreach (Collider2D obj in hitObj)
            {
                if (obj.TryGetComponent(out IHealth health))
                    health.TakeHit(damage);
            }
        }
    }
}