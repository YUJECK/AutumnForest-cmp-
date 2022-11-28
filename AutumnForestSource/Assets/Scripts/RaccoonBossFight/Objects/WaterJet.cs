using UnityEngine;

namespace AutumnForest
{
    public class WaterJet : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.transform.CompareTag("Player"))
                Destroy(collision.gameObject);
            else collision.gameObject?.GetComponent<Health>().TakeHit(15);
        }
    }
}