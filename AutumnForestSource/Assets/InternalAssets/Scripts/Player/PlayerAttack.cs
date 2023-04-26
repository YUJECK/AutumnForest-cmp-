using AutumnForest.Projectiles;
using Cysharp.Threading.Tasks;
using System;
using AutumnForest.BossFight;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AutumnForest.Player
{
    public sealed class PlayerAttack : MonoBehaviour, IDisablable
    {
        [SerializeField] private int damage;
        [SerializeField] private float attackRate = 0.75f;
        private bool canAttack = true;

        [SerializeField] GameObject attackEffect;
        [SerializeField] private AreaHit areaHit;

        private int playerProjectilesLayer = 7;

        public event Action OnEnabled;
        public event Action OnDisabled;
        public bool Enabled { get; private set; }

        private void Awake()
            => Disable();

        private void OnEnable()
        {
            GlobalServiceLocator.GetService<PlayerInput>().Inputs.Attack.performed += Attack;
            GlobalServiceLocator.GetService<BossFightManager>().OnBossFightStarted += Enable;

            areaHit.OnHitted += OnHitted;
        }

        private void OnDisable()
        {
            if (GlobalServiceLocator.TryGetService(out PlayerInput playerInput))
                playerInput.Inputs.Attack.performed -= Attack;
            
            areaHit.OnHitted += OnHitted;
        }

        private async void Attack(InputAction.CallbackContext context)
        {
            if (canAttack && Enabled)
            {
                areaHit.Hit(damage);
                Instantiate(attackEffect, areaHit.transform.position, areaHit.transform.rotation);

                canAttack = false;
                await UniTask.Delay(TimeSpan.FromSeconds(attackRate));
                canAttack = true;
            }
        }

        private void OnHitted(Collider2D[] obj)
        {
            foreach (Collider2D item in obj)
            {
                if (item.TryGetComponent(out Projectile projetile))
                {
                    projetile.Rigidbody2D.velocity *= -1;
                    projetile.SpawnCollideffect();
                    projetile.gameObject.layer = playerProjectilesLayer;
                }
            }
        }

        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }
    }
}