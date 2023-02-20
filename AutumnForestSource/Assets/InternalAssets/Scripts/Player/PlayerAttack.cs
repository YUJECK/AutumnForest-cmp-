using AutumnForest.Projectiles;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AutumnForest.Player
{
    public sealed class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private float attackRate = 0.75f;
        private bool canAttack = true;

        [SerializeField] GameObject attackEffect;
        [SerializeField] private AreaHit areaHit;

        private int playerProjectilesLayer = 7;

        private void Awake()
        {
            if (areaHit == null) throw new NullReferenceException(nameof(areaHit));
            if (attackEffect == null) throw new NullReferenceException(nameof(attackEffect));
        }
        private void OnEnable()
        {
            GlobalServiceLocator.GetService<PlayerInput>().Inputs.Attack.performed += Attack;

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
            if (canAttack)
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

    }
}