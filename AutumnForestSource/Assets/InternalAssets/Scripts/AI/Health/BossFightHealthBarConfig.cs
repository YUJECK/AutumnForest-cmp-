using UnityEngine;

namespace AutumnForest.Health
{
    [CreateAssetMenu(fileName = nameof(BossFightHealthBarConfig), menuName = "BossFight/New Health Bar Config")]
    public class BossFightHealthBarConfig : ScriptableObject
    {
        [field: SerializeField] public string HealthBarName { get; private set; } = "Some creature";
        [field: SerializeField] public Sprite HealthBarIcon { get; private set; }

        public IHealth HealthTarget { get; set; }
    }
}