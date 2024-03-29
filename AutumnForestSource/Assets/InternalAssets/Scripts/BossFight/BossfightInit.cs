﻿using AutumnForest.Health;
using AutumnForest.Managers;
using AutumnForest.Player;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public sealed class BossFightInit : MonoBehaviour
    {
        [SerializeField] private BossFightHealthBar healthBar;

        BossFightManager bossFightManager;

        private void Awake() => bossFightManager = GlobalServiceLocator.GetService<BossFightManager>();

        private void OnEnable()
        {
            bossFightManager.OnBossFightStarted += GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToBossFightCamera;
            bossFightManager.OnBossFightEnded += GlobalServiceLocator.GetService<CameraSwitcher>().SwichToMainCamera;

            bossFightManager.OnBossFightEnded += GlobalServiceLocator.GetService<MusicSwitcher>().SwitchToMainTheme;

            bossFightManager.OnBossFightStarted += EnableHealthBar;
            bossFightManager.OnBossFightEnded += DisableHealthBar;

            bossFightManager.OnBossFightStarted += GlobalServiceLocator.GetService<PlayerDash>().Enable;
            bossFightManager.OnBossFightEnded += GlobalServiceLocator.GetService<PlayerDash>().Disable;
        }

        private void EnableHealthBar() => healthBar.gameObject.SetActive(true);
        private void DisableHealthBar() => healthBar.gameObject.SetActive(false);
    }
}