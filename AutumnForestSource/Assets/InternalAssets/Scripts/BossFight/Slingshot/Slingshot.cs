using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AutumnForest.BossFight.Slingshot
{
    public sealed class Slingshot : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform firePoint;
        [SerializeField] private int culldown = 5;
        
        private bool canShoot = true;
        public bool Enabled { get; private set; } = false;

        public event Action OnReload;
        public event Action OnShoot;
        public event Action<int> OnTimer;

        private void Start()
        {
            DisableSlingshot();
        }
        private void OnEnable()
        {
            if (GlobalServiceLocator.TryGetService(out PlayerInput playerInput))
                playerInput.Inputs.Slingshot.performed += SlingshotInput;
        }
        private void OnDisable()
        {
            if(GlobalServiceLocator.TryGetService(out PlayerInput playerInput))
                playerInput.Inputs.Slingshot.performed -= SlingshotInput;
        }

        public void EnableSlingshot()
        {
            if (!Enabled)
            {
                Enabled = true;
                GlobalServiceLocator.GetService<PlayerInput>().Inputs.Slingshot.Enable();
            }
        }
        public void DisableSlingshot()
        {
            if (Enabled)
            {
                Enabled = false;
                GlobalServiceLocator.GetService<PlayerInput>().Inputs.Slingshot.Disable();
            }
        }

        private void Shoot()
        {
            if (canShoot && Enabled)
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
                OnTimer?.Invoke(i);
                await UniTask.Delay(1000);
            }

            canShoot = true;
            OnReload?.Invoke();
        }

        private void SlingshotInput(InputAction.CallbackContext obj) => Shoot();
    }
}