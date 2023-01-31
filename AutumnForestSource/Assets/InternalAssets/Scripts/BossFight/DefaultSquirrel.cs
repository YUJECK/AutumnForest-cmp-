using AutumnForest.Health;
using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace AutumnForest.BossFight.Squirrels
{
    //супер костыль моментный скрипт
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CreatureHealth))]
    public class DefaultSquirrel : Squirrel
    {
        [SerializeField] private Shooting shooting;
        [SerializeField] private AudioSource shotAudio;

        [SerializeField] private string shotAnimation;
        [SerializeField] private float shootMinimumRate = 2f;
        [SerializeField] private float shootMaximumRate = 3.5f;
        [SerializeField] private float shootSpeed = 10;
        [SerializeField] private float spread = 25;

        private Animator animator;
        private CreatureHealth health;
        private CancellationTokenSource token = new();

        private void Awake()
        {
            health = GetComponent<CreatureHealth>();
            animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            health.OnDie += OnDie;
            shooting.OnShoot += OnShoot;

            EnableSShooting();
        }
        private void OnDisable()
        {
            health.OnDie -= OnDie;
            shooting.OnShoot -= OnShoot;

            DisableShooting();
        }
        private void OnDestroy()
        {
            DisableShooting();
            this.token.Dispose();
        }

        public void EnableSShooting()
        {
            token = new();
            Shooting(token.Token);
        }
        public void DisableShooting()
        {
            if (!token.IsCancellationRequested)
                token.Cancel();
        }

        private async void Shooting(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(UnityEngine.Random.Range(shootMinimumRate, shootMaximumRate)));

                if (gameObject.activeInHierarchy)
                    shooting.ShootWithoutInstantiate(GlobalServiceLocator.GetService<SomePoolsContainer>().AcornPool.GetFree().Rigidbody2D,
                        shootSpeed, UnityEngine.Random.Range(0, spread), ForceMode2D.Impulse);
            }
        }

        private void OnDie() => GlobalServiceLocator.GetService<SomePoolsContainer>().AcornHealPool.GetFree().transform.position = transform.position;
        private void OnShoot(Rigidbody2D obj)
        {
            animator.Play(shotAnimation);
            shotAudio.pitch = UnityEngine.Random.Range(0.35f, 0.75f);
            shotAudio.Play();
        }
    }
}