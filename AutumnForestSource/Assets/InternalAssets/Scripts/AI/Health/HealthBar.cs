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

                healthTarget.OnHealthChange += UpdateHealthBar;
                UpdateHealthBar(healthTarget.CurrentHealth, healthTarget.MaximumHealth);
            }
            else throw new NullReferenceException(nameof(healthBarConfig));
        }
        private void UpdateHealthBar(int currentHealth, int maximumHealth)
        {
            if (healthBar != null)
            {
                healthBar.fillAmount = (float)currentHealth / (float)maximumHealth;
            }
            else throw new NullReferenceException(nameof(healthBar));
        }
    }
}