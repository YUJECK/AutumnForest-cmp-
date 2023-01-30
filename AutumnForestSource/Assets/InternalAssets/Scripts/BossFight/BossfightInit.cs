using AutumnForest.BossFight.Raccoon;
using AutumnForest.Health;
using AutumnForest.Managers;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public sealed class BossfightInit : MonoBehaviour
    {
        [SerializeField] private BossFightHealthBar healthBar;
        [SerializeField] private GameObject log;

        BossFightManager bossFightManager;

        private void Awake() => bossFightManager = GlobalServiceLocator.GetService<BossFightManager>();

        private void OnEnable()
        {
            bossFightManager.OnBossFightStarted += GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToBossFightCamera;
            bossFightManager.OnBossFightEnded += GlobalServiceLocator.GetService<CameraSwitcher>().SwichToMainCamera;

            bossFightManager.OnBossFightStarted += EnableHealthBar;
            bossFightManager.OnBossFightEnded += DisableHealthBar;

            bossFightManager.OnBossFightStarted += EnableLog;
            bossFightManager.OnBossFightStarted += DisableLog;

            GlobalServiceLocator.GetService<RaccoonStateMachineUser>().ServiceLocator
                .GetService<CreatureHealth>()
                .OnDie += bossFightManager.EndBossFight;
        }

        private void OnDisable()
        {
            bossFightManager.OnBossFightStarted -= GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToBossFightCamera;
            bossFightManager.OnBossFightEnded -= GlobalServiceLocator.GetService<CameraSwitcher>().SwichToMainCamera;

            bossFightManager.OnBossFightStarted -= EnableHealthBar;
            bossFightManager.OnBossFightEnded -= DisableHealthBar;

            bossFightManager.OnBossFightStarted -= EnableLog;
            bossFightManager.OnBossFightStarted -= DisableLog;
            
            GlobalServiceLocator.GetService<RaccoonStateMachineUser>().ServiceLocator.GetService<CreatureHealth>().OnDie -= bossFightManager.EndBossFight;
        }

        private void EnableHealthBar() => healthBar.gameObject.SetActive(true);
        private void EnableLog() => log.SetActive(true);
        private void DisableHealthBar() => healthBar.gameObject.SetActive(false);
        private void DisableLog() => log.SetActive(false);
    }
}