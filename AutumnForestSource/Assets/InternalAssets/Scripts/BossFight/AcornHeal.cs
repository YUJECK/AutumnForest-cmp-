using AutumnForest.Health;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public class AcornHeal : MonoBehaviour
    {
        [SerializeField] int heal = 5;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag(TagHelper.PlayerTag))
            {
                collision.collider.GetComponent<IHealth>().Heal(heal);
                gameObject.SetActive(false);
            }
        }
    }
}