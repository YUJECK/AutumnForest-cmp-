using UnityEngine;

namespace CreaturesAI.Health
{
    [CreateAssetMenu]
    public class HealthBarPreset : ScriptableObject
    {
        //fields
        [SerializeField] private string healthBarName = "Some creature";
        [SerializeField] private Sprite healthBarIcon;
        [SerializeField] private Health healthTarget;

        //getters
        public string HealthBarName => healthBarName;
        public Sprite HealthBarIcon => healthBarIcon;
        public Health HealthTarget { get => healthTarget; set { if (value != null) healthTarget = value; } }
    }
}