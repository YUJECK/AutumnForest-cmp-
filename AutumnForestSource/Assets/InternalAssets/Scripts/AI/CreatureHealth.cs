using System;
using UnityEngine;

namespace CreaturesAI.Health
{
    public class CreatureHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private bool destroyOnDie = true;

        [SerializeField] private int currentHealth;
        [SerializeField] private int maximumHealth;

        public int CurrentHealth { get => currentHealth; private set => currentHealth = value; }
        public int MaximumHealth { get => maximumHealth; private set => maximumHealth = value; }

        public event Action<int, int> OnHealthChange;
        public event Action<int, int> OnHeal;
        public event Action<int, int> OnTakeHit;
        public event Action OnDie;

        public void DecreaseMaximumHealth(int damagePoints)
        {
            maximumHealth -= damagePoints;
            OnHealthChange?.Invoke(currentHealth, maximumHealth);
        }
        public void IncreaseMaximumHealth(int healPoints)
        {
            maximumHealth += healPoints;
            OnHealthChange?.Invoke(currentHealth, maximumHealth);
        }
        
        public void Heal(int healPoints)
        {
            currentHealth += healPoints;
            OnHeal?.Invoke(currentHealth, maximumHealth);
            OnHealthChange?.Invoke(currentHealth, maximumHealth);

            if (currentHealth > maximumHealth)
                currentHealth = maximumHealth;
        }
        public void TakeHit(int damagePoints)
        {
            currentHealth -= damagePoints;
            OnTakeHit?.Invoke(currentHealth, maximumHealth);
            OnHealthChange?.Invoke(currentHealth, maximumHealth);

            if (currentHealth <= 0)
            {
                OnDie?.Invoke();
                if (destroyOnDie) Destroy(gameObject);
            }
        }
    }
}