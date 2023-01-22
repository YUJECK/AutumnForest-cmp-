using CreaturesAI.Health;
using UnityEngine;

public class CollsionHeal : MonoBehaviour
{
    [SerializeField] int heal = 5;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<IHealth>().Heal(heal);
            Destroy(gameObject);
        }
    }
}