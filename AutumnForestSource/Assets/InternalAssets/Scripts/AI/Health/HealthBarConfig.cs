using UnityEngine;

namespace AutumnForest.Health
{
    [CreateAssetMenu]
    public class HealthBarConfig : ScriptableObject
    {
        [field: SerializeField] public string HealthBarName { get; private set; } = "Some creature";
        [field: SerializeField] public Sprite HealthBarIcon { get; private set; }

        public IHealth HealthTarget { get; set; }
    }
}