using AutumnForest.Helpers;
using AutumnForest.Other;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace AutumnForest.BossFight.Slingshot
{
    public sealed class Slingshot : MonoBehaviour
    {
        [SerializeField] private int culldown = 5;
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform firePoint;
        private bool canShoot = true;
        public bool Enabled { get; private set; } = false;

        public event Action OnReady;
        public event Action OnShoot;
        public event Action OnTimer;


        private void Start()
        {
            DisableSlingshot();
        }
        private void OnEnable()
        {
            GlobalServiceLocator.GetService<PlayerInput>().Inputs.Slingshot.performed += SlingshotInput;
        }
        private void OnDisable()
        {
            GlobalServiceLocator.GetService<PlayerInput>().Inputs.Slingshot.performed -= SlingshotInput;
        }

        public void EnableSlingshot()
        {
            Enabled = true;
            GlobalServiceLocator.GetService<PlayerInput>().Inputs.Slingshot.Enable();
        }
        public void DisableSlingshot()
        {
            Enabled = false;
            GlobalServiceLocator.GetService<PlayerInput>().Inputs.Slingshot.Disable();
        }

        private void Shoot()
        {
            if(canShoot && Enabled)
            {
                Instantiate(projectile, firePoint.position, firePoint.rotation);
                OnShoot?.Invoke();
                
                Culldown();
            }
        }
        private async void Culldown()
        {
            canShoot = false;

            for (int i = 0; i < culldown; i++)
            {
                OnTimer?.Invoke();
                await UniTask.Delay(1000);
            }

            canShoot = true;
            OnReady?.Invoke();
        }

        private void SlingshotInput(InputAction.CallbackContext obj) => Shoot();
    }
}