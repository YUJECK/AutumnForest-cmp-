using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public class AreaHit : MonoBehaviour
    {
        //feilds
        public UnityEvent OnHitting = new UnityEvent();
        [SerializeField] private float attackRange = 0.3f;
        [SerializeField] private int damageLayer = 0;

        //methods
        public bool Hit(int damage)
        {
            //define hitted objects
            bool isHitSomeone = false;
            Collider2D[] hitObj = Physics2D.OverlapCircleAll(transform.position, attackRange);
            OnHitting.Invoke();

            //checking every hit objects for the presence of a Health component
            foreach (Collider2D obj in hitObj)
            {
                if (obj.TryGetComponent(out Health health))
                {
                    health.TakeHit(damage);
                    isHitSomeone = true;
                }
            }
            return isHitSomeone;
        }
    }
}