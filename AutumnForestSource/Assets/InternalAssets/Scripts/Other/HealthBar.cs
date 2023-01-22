using System;
using UnityEngine;
using UnityEngine.UI;

namespace CreaturesAI.Health
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        [SerializeField] private Image healthBarIcon;
        [SerializeField] private Text healthBarText;
        
        private IHealth healthTarget;

        //methods
        public void SetPreset(HealthBarPreset healthBarPreset)
        {
            if (healthBarPreset != null)
            {
                healthTarget = healthBarPreset.HealthTarget;
                healthBarIcon.sprite = healthBarPreset.HealthBarIcon;
                healthBarText.text = healthBarPreset.HealthBarName;

                healthTarget.OnHealthChange += UpdateHealthBar;
                UpdateHealthBar(healthTarget.CurrentHealth, healthTarget.MaximumHealth);
            }
            else throw new NullReferenceException(nameof(healthBarPreset));
        }
        private void UpdateHealthBar(int currentHealth, int maximumHealth)
        {
            if (healthBar != null)
            {
                healthBar.value = currentHealth;
                healthBar.maxValue = maximumHealth;
            }
            else throw new NullReferenceException(nameof(healthBar));
        }
    }
}