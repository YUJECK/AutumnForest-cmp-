using AutumnForest.Other;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace AutumnForest.BossFight
{
    [RequireComponent(typeof(InteractionField))]
    public sealed class SlingshotShoot : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform firePoint;
        [SerializeField] private Text culldownText;
        [SerializeField] private PointRotation pointRotation;
        private bool canShoot = true;
        private bool isActivated = false;

        public UnityEvent OnShoot = new();
        public bool IsActivated => isActivated;

        public void ActivateSlingshot()
        {
            ServiceLocator.GetService<PlayerInput>().Player.Attack.performed += Shoot;
            isActivated = true;
        }
        public void DisableSlingshot()
        {
            ServiceLocator.GetService<PlayerInput>().Player.Attack.performed -= Shoot;
            isActivated = false;
        }
        private void Shoot(InputAction.CallbackContext context)
        {
            if (canShoot)
            {
                Instantiate(projectile, firePoint.position, firePoint.rotation);
                OnShoot.Invoke();
                DisableSlingshot();
                Culldown();
            }
        }
        private async void Culldown()
        {
            canShoot = false;

            for (int i = 0; i < 5; i++)
            {
                culldownText.text = (5 - i).ToString();
                await Task.Delay(1000);
            }
            culldownText.text = "";

            canShoot = true;
        }
    }
}