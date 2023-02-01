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

        private void Awake()
        {
            if (areaHit == null) throw new NullReferenceException(nameof(areaHit));
            if (attackEffect == null) throw new NullReferenceException(nameof(attackEffect));
        }
        private void OnEnable() => GlobalServiceLocator.GetService<PlayerInput>().Inputs.Attack.performed += Attack;
        private void OnDisable() => GlobalServiceLocator.GetService<PlayerInput>().Inputs.Attack.performed -= Attack;

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
    }
}