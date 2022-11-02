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
        RaycastHit2D[] hittedObjects = Physics2D.RaycastAll(attackPoint.position, Vector2.zero, attackRange);

        foreach (RaycastHit2D item in hittedObjects)
        {
            if (item.transform.gameObject.TryGetComponent(out Health health))
                health.TakeHit(damage);
        }
    }

}