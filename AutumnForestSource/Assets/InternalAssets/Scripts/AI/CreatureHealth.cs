using System;
using UnityEngine;

namespace AutumnForest.Health
{
    public class CreatureHealth : MonoBehaviour, IHealth
    {
        public enum DieEvents
        {
            Destroy,
            Disable,
            Nothing
        }

        [SerializeField] private DieEvents dieEvent;
        [field: SerializeField] public HealthBarConfig HealthBarConfig { get; private set; }

        [field: SerializeField] public int CurrentHealth { get; private set; }
        [field: SerializeField] public int MaximumHealth { get; private set; }

        public event Action<int, int> OnHealthChange;
        public event Action<int, int> OnHeal;
        public event Action<int, int> OnTakeHit;
        public event Action OnDie;

        private void Awake()
        {
            if(HealthBarConfig != null)
                HealthBarConfig.HealthTarget = this;
        }
        
        public void Heal(int healPoints)
        {
            CurrentHealth += healPoints;

            OnHeal?.Invoke(CurrentHealth, MaximumHealth);
            OnHealthChange?.Invoke(CurrentHealth, MaximumHealth);

            if (CurrentHealth > MaximumHealth)
                CurrentHealth = MaximumHealth;
        }
        public void TakeHit(int damagePoints)
        {
            CurrentHealth -= damagePoints;

            OnTakeHit?.Invoke(CurrentHealth, MaximumHealth);
            OnHealthChange?.Invoke(CurrentHealth, MaximumHealth);

            if (CurrentHealth <= 0)
            {
                OnDie?.Invoke();

                switch (dieEvent)
                {
                    case DieEvents.Destroy:
                        Destroy(gameObject);
                        break;
                    case DieEvents.Disable:
                        gameObject.SetActive(false);
                        break;
                    case DieEvents.Nothing:
                        return;
                }
            }
        }
    }
}