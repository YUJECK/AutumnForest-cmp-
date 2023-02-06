using AutumnForest.BossFight.Raccoon;
using AutumnForest.Health;
using AutumnForest.Managers;
using AutumnForest.Player;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public sealed class BossFightInit : MonoBehaviour
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

            bossFightManager.OnBossFightStarted += GlobalServiceLocator.GetService<PlayerDash>().Enable;
            bossFightManager.OnBossFightEnded += GlobalServiceLocator.GetService<PlayerDash>().Disable;

            bossFightManager.OnBossFightStarted += EnableLog;
            bossFightManager.OnBossFightStarted += DisableLog;

            GlobalServiceLocator.GetService<RaccoonStateMachineUser>().ServiceLocator
                .GetService<CreatureHealth>()
                .OnDied += bossFightManager.EndBossFight;
        }

        private void OnDisable()
        {
            bossFightManager.OnBossFightStarted -= GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToBossFightCamera;
            bossFightManager.OnBossFightEnded -= GlobalServiceLocator.GetService<CameraSwitcher>().SwichToMainCamera;
            
            bossFightManager.OnBossFightStarted -= GlobalServiceLocator.GetService<PlayerDash>().Enable;
            bossFightManager.OnBossFightEnded -= GlobalServiceLocator.GetService<PlayerDash>().Disable;

            bossFightManager.OnBossFightStarted -= EnableHealthBar;
            bossFightManager.OnBossFightEnded -= DisableHealthBar;

            bossFightManager.OnBossFightStarted -= EnableLog;
            bossFightManager.OnBossFightStarted -= DisableLog;
            
            GlobalServiceLocator.GetService<RaccoonStateMachineUser>().ServiceLocator.GetService<CreatureHealth>().OnDied -= bossFightManager.EndBossFight;
        }

        private void EnableHealthBar() => healthBar.gameObject.SetActive(true);
        private void EnableLog() => log.SetActive(true);
        private void DisableHealthBar() => healthBar.gameObject.SetActive(false);
        private void DisableLog() => log.SetActive(false);
    }
}