using AutumnForest.BossFight;
using UnityEngine;

namespace AutumnForest
{
    public class BossFightTrigger : MonoBehaviour
    {
        private BossFightManager bossFightManager;

        private void Awake()
        {
            bossFightManager = GlobalServiceLocator.GetService<BossFightManager>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(TagHelper.PlayerTag))
            {
                if (bossFightManager.CurrentStage == BossFightStage.NotStarted)
                    bossFightManager.StartBossFight();            
            }
        }
    }
}