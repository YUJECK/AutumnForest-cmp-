using UnityEngine;

namespace AutumnForest
{
    public class CreatureHealth : Health
    {
        [SerializeField] private bool destroyOnDie = true; 

        public override void DecreaseMaximumHealth(int damagePoints)
        {
            maximumHealth -= damagePoints;
            OnHealthChange.Invoke(currentHealth, maximumHealth);
        }

        public override void Heal(int healPoints)
        {
            currentHealth += healPoints;
            OnHeal.Invoke(currentHealth, maximumHealth);
            OnHealthChange.Invoke(currentHealth, maximumHealth);

            if (currentHealth > maximumHealth)
                currentHealth = maximumHealth;
        }

        public override void IncreaseMaximumHealth(int healPoints)
        {
            maximumHealth += healPoints;
            OnHealthChange.Invoke(currentHealth, maximumHealth);
        }

        public override void TakeHit(int damagePoints)
        {
            currentHealth -= damagePoints;
            OnTakeHit.Invoke(currentHealth, maximumHealth);
            OnHealthChange.Invoke(currentHealth, maximumHealth);

            if (currentHealth <= 0)
            {
                OnDie.Invoke();
                if (destroyOnDie) Destroy(gameObject);
            }
        }
    }
}