using UnityEngine;

public class Combat : MonoBehaviour
{
    //variables
    [SerializeField] private int damage;
    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPoint;

    //getters
    public Transform AttackPoint => attackPoint;

    //methods
    public void Hit()
    {
        Collider2D[] hittedObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        
        foreach (Collider2D item in hittedObjects)
        {
            if (item.transform.gameObject.TryGetComponent(out Health health))
                health.TakeHit(damage);
        }
    }
    private void OnDrawGizmos()
    {
        if(attackPoint!=null)
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}