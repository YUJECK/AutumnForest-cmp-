using UnityEngine;

namespace CreaturesAI.Health
{
    [CreateAssetMenu]
    public class HealthBarPreset : ScriptableObject
    {
        //fields
        [SerializeField] private string healthBarName = "Some creature";
        [SerializeField] private Sprite healthBarIcon;
        [SerializeField] private IHealth healthTarget;

        //getters
        public string HealthBarName => healthBarName;
        public Sprite HealthBarIcon => healthBarIcon;
        public IHealth HealthTarget { get => healthTarget; set { if (value != null) healthTarget = value; } }
    }
}