using AutumnForest.Health;
using AutumnForest.Helpers;
using CreaturesAI.CombatSkills;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace AutumnForest.BossFight.Squirrels
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CreatureHealth))]
    public class DefaultSquirrel : Squirrel
    {
        [SerializeField] private Shooting shooting;
        private CreatureHealth health;
        private Animator animator;

        [SerializeField] private string shotAnimation;
        [SerializeField] private float shootMinimumRate = 2f;
        [SerializeField] private float shootMaximumRate = 3.5f;
        [SerializeField] private float shootSpeed = 10;
        [SerializeField] private float spread = 25;

        private CancellationTokenSource token = new();

        private void Awake()
        {
            health = GetComponent<CreatureHealth>();
            animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            health.OnDie += SpawnHealAcorn;
            shooting.OnShoot += OnShoot;

            Enable();
        }
        private void OnDisable()
        {
            health.OnDie -= SpawnHealAcorn;
            shooting.OnShoot -= OnShoot;

            Disable();
        }
        private void OnDestroy() => Disable();

        public void Enable()
        {
            token = new();
            Shooting(token.Token);
        }
        public void Disable()
        {
            token.Cancel();
        }

        private async void Shooting(CancellationToken token)
        {
            while (true)
            {
                try
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(UnityEngine.Random.Range(shootMinimumRate, shootMaximumRate)), cancellationToken: token);
                    
                    shooting.ShootWithoutInstantiate(GlobalServiceLocator.GetService<SomePoolsContainer>().AcornPool.GetFree().Rigidbody2D,
                        shootSpeed, UnityEngine.Random.Range(0, spread), ForceMode2D.Impulse, gameObject);
                }
                catch
                {
                    Debug.Log("Canceled");
                    this.token.Dispose();
                    return;
                }
            }
        }

        private void SpawnHealAcorn()
        {
            GlobalServiceLocator.GetService<SomePoolsContainer>().AcornHealPool.GetFree().transform.position = transform.position;
        }
        private void OnShoot(Rigidbody2D obj)
        {
            animator.Play(shotAnimation);
        }
    }
}