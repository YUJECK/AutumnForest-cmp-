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
            MaximumHealth -= damagePoints;
            OnHealthChange?.Invoke(CurrentHealth, MaximumHealth);
        }

        public void Heal(int healPoints)
        {
            CurrentHealth += healPoints;
            OnHeal?.Invoke(CurrentHealth, MaximumHealth);
            OnHealthChange?.Invoke(CurrentHealth, MaximumHealth);

            if (CurrentHealth > MaximumHealth)
                CurrentHealth = MaximumHealth;
        }

        public void IncreaseMaximumHealth(int healPoints)
        {
            MaximumHealth += healPoints;
            OnHealthChange?.Invoke(CurrentHealth, MaximumHealth);
        }
        public void TakeHit(int damagePoints)
        {
            CurrentHealth -= damagePoints;
            OnTakeHit?.Invoke(CurrentHealth, MaximumHealth);
            OnHealthChange?.Invoke(CurrentHealth, MaximumHealth);

            if (CurrentHealth <= 0)
            {
                OnDie?.Invoke();
                if (destroyOnDie) Destroy(gameObject);
            }
        }
    }
}