using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.Health
{
    [DisallowMultipleComponent]
    public class BossFightHealthBar : MonoBehaviour
    {
        [SerializeField, Expandable] BossFightHealthBarConfig healthBarConfig;

        [SerializeField] private Image healthBarIcon;
        [SerializeField] private Image healthBarFill;
        [SerializeField] private Text healthBarText;

        private HealthBar healthBar;

        private void OnEnable()
        {
            healthBar = new(healthBarFill);

            if (healthBarConfig != null)
                SetConfig(healthBarConfig);
        }

        public void SetConfig(BossFightHealthBarConfig healthBarConfig)
        {
            if (healthBarConfig == null)
                throw new NullReferenceException(nameof(healthBarConfig));

            healthBarIcon.sprite = healthBarConfig.HealthBarIcon;
            healthBarText.text = healthBarConfig.HealthBarName;

            if(healthBarConfig.HealthTarget != null)
                healthBar.SwitchTarget(healthBarConfig.HealthTarget);
        }
    }
}