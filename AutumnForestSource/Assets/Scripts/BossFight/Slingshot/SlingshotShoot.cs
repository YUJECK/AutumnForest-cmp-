using AutumnForest.Other;
using AutumnForest.Player;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AutumnForest.BossFight
{
    [RequireComponent(typeof(InteractionField))]
    public class SlingshotShoot : MonoBehaviour
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
            ServiceLocator.GetService<PlayerInput>().OnLeftMouseButtonPressed.AddListener(Shoot);
            isActivated = true;
        }
        public void DisableSlingshot()
        {
            ServiceLocator.GetService<PlayerInput>().OnLeftMouseButtonPressed.RemoveListener(Shoot);
            isActivated = false;
        }
        private void Shoot()
        {
            if (canShoot)
            {
                Instantiate(projectile, firePoint.position, firePoint.rotation);
                OnShoot.Invoke();
                ServiceLocator.GetService<PlayerInput>().OnLeftMouseButtonPressed.RemoveListener(Shoot);
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