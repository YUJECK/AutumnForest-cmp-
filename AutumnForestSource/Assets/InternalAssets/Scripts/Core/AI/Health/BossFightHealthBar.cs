using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.Health
{
    [DisallowMultipleComponent]
    public sealed class BossFightHealthBar : MonoBehaviour
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
            if (healthBar == null) healthBar = new(healthBarFill);
            if (healthBarConfig == null) Debug.LogError("Health bar config null");

            healthBarIcon.sprite = healthBarConfig.HealthBarIcon;
            healthBarText.text = healthBarConfig.HealthBarName.Value;
            this.healthBarConfig = healthBarConfig;

            if(healthBarConfig.HealthTarget != null)
                healthBar.SwitchTarget(healthBarConfig.HealthTarget);
        }
    }
}