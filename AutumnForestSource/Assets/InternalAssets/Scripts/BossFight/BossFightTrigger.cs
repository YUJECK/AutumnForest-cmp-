using AutumnForest.BossFight;
using AutumnForest.Health;
using AutumnForest.Managers;
using UnityEngine;

namespace AutumnForest
{
    public class BossFightTrigger : MonoBehaviour
    {
        private BossFightManager bossFightManager;
        [SerializeField] private HealthBar bossfightHealthBar; //временно
        [SerializeField] private CreatureHealth creatureHealth; //временно

        private void Awake()
        {
            bossFightManager = GlobalServiceLocator.GetService<BossFightManager>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(TagHelper.PlayerTag))
            {
                if (bossFightManager.CurrentStage == BossFightStage.NotStarted)
                {
                    bossFightManager.StartBossFight();
                    GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToBossFightCamera(); //временно
                    bossfightHealthBar.SetConfig(creatureHealth.healthBarConfig); //временно
                }
            }
        }
    }
}