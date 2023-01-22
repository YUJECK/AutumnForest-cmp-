using CreaturesAI.Health;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public class AreaHit : MonoBehaviour
    {
        //feilds
        public UnityEvent OnHitting = new UnityEvent();
        [SerializeField] private float attackRange = 0.3f;
        [SerializeField, Layer] private int damageLayer = 0;

        //unity methods
        private void OnDrawGizmos() => Gizmos.DrawWireSphere(transform.position, attackRange);

        //methods
        public void Hit(int damage = 10)
        {
            //define hitted 
            Collider2D[] hitObj = Physics2D.OverlapCircleAll(transform.position, attackRange);
            OnHitting.Invoke();

            //checking every hit objects for the presence of a Health component
            foreach (Collider2D obj in hitObj)
            {
                if (obj.TryGetComponent(out IHealth health))
                    health.TakeHit(damage);
            }
        }
    }
}