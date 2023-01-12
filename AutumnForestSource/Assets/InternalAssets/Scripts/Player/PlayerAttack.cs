using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AutumnForest.Player
{
    public sealed class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private int attackRate = 1000;
        private bool canAttack = true;

        [SerializeField] GameObject attackAnimation;
        [SerializeField] private AreaHit areaHit;

        private void OnEnable() => GlobalServiceLocator.GetService<PlayerInput>().Inputs.Attack.performed += Attack;
        private void OnDisable() => GlobalServiceLocator.GetService<PlayerInput>().Inputs.Attack.performed -= Attack;

        private void Attack(InputAction.CallbackContext context)
        {
            if (canAttack)
            {
                if (areaHit != null && attackAnimation != null)
                {
                    areaHit.Hit(damage);
                    Instantiate(attackAnimation, areaHit.transform.position, areaHit.transform.rotation);
                }
                else Debug.LogError("Some reference not setted");
                
                AttackCulldown();
            }

            async void AttackCulldown()
            {
                canAttack = false;
                await Task.Delay(attackRate);
                canAttack = true;
            }
        }
    }
}