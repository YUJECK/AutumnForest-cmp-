using AutumnForest.BossFight;
using UnityEngine;

namespace AutumnForest
{
    public class BossFightTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(TagHelper.PlayerTag))
            {

                Debug.Log("asds"); 
                BossFightManager.StartBossFight();

            }
        }
    }
}