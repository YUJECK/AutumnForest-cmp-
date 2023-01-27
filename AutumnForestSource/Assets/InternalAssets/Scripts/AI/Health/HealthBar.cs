using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.Health
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField, Expandable] HealthBarConfig healthBarConfig;
        [SerializeField] private Image healthBar;
        [SerializeField] private Image healthBarIcon;
        [SerializeField] private Text healthBarText;
        
        private IHealth healthTarget;

        //methods
        public void SetConfig(HealthBarConfig healthBarConfig)
        {
            if (healthBarConfig != null)
            {
                healthTarget = healthBarConfig.HealthTarget;
                healthBarIcon.sprite = healthBarConfig.HealthBarIcon;
                healthBarText.text = healthBarConfig.HealthBarName;

                healthTarget.OnHealthChange += OnHealthChanged;
                OnHealthChanged(healthTarget.CurrentHealth, healthTarget.MaximumHealth);
            }
            else throw new NullReferenceException(nameof(healthBarConfig));
        }
        private void OnHealthChanged(int currentHealth, int maximumHealth)
        {
            if (healthBar != null)
                UpdateHealthBar(currentHealth, maximumHealth);
            else throw new NullReferenceException(nameof(healthBar));
        }
        private async UniTask UpdateHealthBar(int currentHealth, int maximumHealth)
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