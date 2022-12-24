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
        //fields
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform firePoint;
        [SerializeField] private Text culldownText;
        private bool canShoot = true;
        [SerializeField] private PointRotation pointRotation;
        public UnityEvent OnShoot = new();

        //unity methods
        private void Start()
        {
            OnShoot.AddListener(Culldown);
            OnShoot.AddListener(delegate { ServiceLocator.GetService<PlayerInput>().OnLeftMouseButtonPressed.RemoveListener(Shoot); });
        }

        //shooting controll methods
        private void Shoot()
        {
            if (canShoot)
            {
                Instantiate(projectile, firePoint.position, firePoint.rotation);
                OnShoot.Invoke();
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
        //other methods
        public void Active() => ServiceLocator.GetService<PlayerInput>().OnLeftMouseButtonPressed.AddListener(Shoot);
    }
}