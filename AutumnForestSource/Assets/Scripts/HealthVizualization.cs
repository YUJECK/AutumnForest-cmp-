using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest
{
    [RequireComponent(typeof(CreatureHealth))]
    public class HealthVizualization : MonoBehaviour
    {
        private enum VizualizationType
        {
            HealthBar,
            Counter
        }

        [SerializeField] private VizualizationType type = VizualizationType.Counter;
        [SerializeField] private Slider healthBar;
        [SerializeField] private Text healthCounter;

        private CreatureHealth health;

        //untiy methods
        private void Awake() => health = GetComponent<CreatureHealth>();
        private void Start()
        {
            switch (type)
            {
                case VizualizationType.HealthBar:
                    health.onHealthChange.AddListener(UpdateHealthBar);
                    break;
                case VizualizationType.Counter:
                    health.onHealthChange.AddListener(UpdateHealthCounter);
                    break;
            }
        }

        //vizualization methods
        private void UpdateHealthBar(int currentHealth, int maximumHealth)
        {
            if (healthBar != null)
            {
                healthBar.value = currentHealth;
                healthBar.maxValue = maximumHealth;
            }
            else Debug.LogError("Null reference. healthBar is null");
        }
        private void UpdateHealthCounter(int currentHealth, int maximumHealth)
        {
            if (healthCounter != null)
                healthCounter.text = $"{currentHealth}/{maximumHealth}";
            else Debug.LogError("Null reference. healthCounter is null");
        }
    }
}