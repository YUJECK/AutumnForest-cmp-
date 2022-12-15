using CreaturesAI.Health;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public class WaterJet : MonoBehaviour
    {
        [SerializeField] private int waterJetDamage = 8;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent(out Health health))
                health.TakeHit(waterJetDamage);
        }
    }
}