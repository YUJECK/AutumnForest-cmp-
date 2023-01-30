using AutumnForest.Health;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest
{
    public sealed class HealthBar
    {
        private IHealth healthTarget;
        [SerializeField] private Image healthBar;

        public HealthBar(Image healthBar, IHealth healthTarget = null)
        {
            if (healthBar == null) throw new NullReferenceException(nameof(healthBar));
            this.healthBar = healthBar;

            if (healthTarget != null)
                SwitchTarget(healthTarget);
        }

        public void SwitchTarget(IHealth healthTarget)
        {
            this.healthTarget = healthTarget;
            this.healthTarget.OnHealthChange += OnHealthChanged;
            
            UpdateHealthBar(healthTarget.CurrentHealth, healthTarget.MaximumHealth);
        }

        private void OnHealthChanged(int currentHealth, int maximumHealth)
        {
            if (healthBar != null) UpdateHealthBar(currentHealth, maximumHealth);
            else throw new NullReferenceException(nameof(healthBar));
        }
        private async void UpdateHealthBar(int currentHealth, int maximumHealth)
        {
            float lastFillAmount = healthBar.fillAmount;
            float toFillAmount = currentHealth / (float)maximumHealth;

            for (float i = 0; i <= 1; i += 0.1f)
            {
                healthBar.fillAmount = Mathf.Lerp(lastFillAmount, toFillAmount, i);
                await UniTask.Delay(10);
            }
        }
    }
}
