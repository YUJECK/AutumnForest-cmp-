using AutumnForest.Health;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public class AreaHit : MonoBehaviour
    {
        public UnityEvent OnHitting = new();
        [SerializeField] private float attackRange = 0.3f;
        [SerializeField, Layer] private int damageLayer = 0;

        private void OnDrawGizmos() => Gizmos.DrawWireSphere(transform.position, attackRange);

        public void Hit(int damage = 10)
        {
            Collider2D[] hitObj = Physics2D.OverlapCircleAll(transform.position, attackRange);
            OnHitting.Invoke();

            foreach (Collider2D obj in hitObj)
            {
                if (obj.TryGetComponent(out IHealth health))
                    health.TakeHit(damage);
            }
        }
    }
}