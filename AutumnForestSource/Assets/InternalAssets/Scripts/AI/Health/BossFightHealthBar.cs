using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.Health
{
    public class BossFightHealthBar : MonoBehaviour
    {
        [SerializeField, Expandable] HealthBarConfig healthBarConfig;

        [SerializeField] private Image healthBarIcon;
        [SerializeField] private Image healthBarFill;
        [SerializeField] private Text healthBarText;

        private HealthBar healthBar;

        private void Awake()
        {
            healthBar = new(healthBarFill);

            if (healthBarConfig != null)
                SetConfig(healthBarConfig);

            //костыли
            gameObject.SetActive(false);
        }

        public void SetConfig(HealthBarConfig healthBarConfig)
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