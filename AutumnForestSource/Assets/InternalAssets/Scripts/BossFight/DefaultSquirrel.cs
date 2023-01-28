using AutumnForest.Assets.InternalAssets.Scripts;
using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using CreaturesAI.CombatSkills;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest
{
    [RequireComponent(typeof(Animator))]
    public class DefaultSquirrel : MonoBehaviour
    {
        [SerializeField] private Projectile acornPrefab;
        [SerializeField] private Shooting shooting;

        [SerializeField] private string shotAnimation;
        [SerializeField] private float shootRate = 2.5f;
        [SerializeField] private float shootSpeed = 10;
        [SerializeField] private float spread = 10;

        private static ObjectPool<Projectile> acornPool;

        private void Start()
        {
            acornPool = new(acornPrefab, GlobalServiceLocator.GetService<ContainerHelper>().ProjectileContainer, 10, true);
            shooting.OnShoot += OnShoot;

            Shooting();
        }

        private void OnShoot(Rigidbody2D obj)
        {
            GetComponent<Animator>().Play(shotAnimation);
        }

        private async void Shooting()
        {
            while (true)
            { 
                shooting.ShootWithInstantiate(acornPool.GetFree().Rigidbody2D, shootSpeed, UnityEngine.Random.Range(0, spread), ForceMode2D.Impulse);
                await UniTask.Delay(TimeSpan.FromSeconds(shootRate));
            }
        }
    }
}