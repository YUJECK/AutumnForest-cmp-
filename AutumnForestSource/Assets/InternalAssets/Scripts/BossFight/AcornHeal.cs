using AutumnForest.Health;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public class AcornHeal : MonoBehaviour
    {
        [SerializeField] int heal = 5;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out IHealth health))
                health.Heal(heal);
            
            gameObject.SetActive(false);
        }
    }
}