using UnityEngine;

namespace AutumnForest.BossFight.Raccoon.States
{
    [CreateAssetMenu(fileName = "New " + nameof(RacconHealingStateConfig), menuName = "BossFight/StatesConfigs/Raccoon Healing State Config")]
    public class RacconHealingStateConfig : ScriptableObject
    {
        [field: SerializeField] public float HealRate { get; private set; }
        [field: SerializeField] public int HealPoints { get; private set; }
    }
}