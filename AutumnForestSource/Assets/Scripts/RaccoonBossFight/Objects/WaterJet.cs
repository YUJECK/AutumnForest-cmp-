using UnityEngine;

namespace AutumnForest
{
    public class WaterJet : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision) => collision.gameObject?.GetComponent<Health>().TakeHit(15);
    }
}