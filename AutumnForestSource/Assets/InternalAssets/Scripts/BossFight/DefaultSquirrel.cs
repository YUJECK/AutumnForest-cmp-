using AutumnForest.Health;
using AutumnForest.Helpers;
using CreaturesAI.CombatSkills;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Squirrels
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CreatureHealth))]
    public class DefaultSquirrel : Squirrel
    {
        [SerializeField] private Shooting shooting;
        private CreatureHealth health;
        private Animator animator;

        [SerializeField] private string shotAnimation;
        [SerializeField] private float shootRate = 2.5f;
        [SerializeField] private float shootSpeed = 10;
        [SerializeField] private float spread = 10;


        private void Awake()
        {
            health = GetComponent<CreatureHealth>();
            animator = GetComponent<Animator>();

            Shooting();
        }
        private void OnEnable()
        {
            health.OnDie += SpawnHealAcorn;
            shooting.OnShoot += OnShoot;
        }
        private void OnDisable()
        {
            health.OnDie -= SpawnHealAcorn;
            shooting.OnShoot -= OnShoot;
        }

        private void SpawnHealAcorn()
        {

        }

        private void OnShoot(Rigidbody2D obj)
        {
            animator.Play(shotAnimation);
        }

        private async void Shooting()
        {
            while (true)
            {
                shooting.ShootWithoutInstantiate(GlobalServiceLocator.GetService<SomePoolsContainer>().AcornPool.GetFree().Rigidbody2D,
                    shootSpeed, UnityEngine.Random.Range(0, spread), ForceMode2D.Impulse);
                await UniTask.Delay(TimeSpan.FromSeconds(shootRate));
            }
        }
    }
}