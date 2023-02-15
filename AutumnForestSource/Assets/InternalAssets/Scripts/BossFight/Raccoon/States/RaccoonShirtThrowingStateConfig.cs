using UnityEngine;

namespace AutumnForest.BossFight.Raccoon.States
{
    [CreateAssetMenu(
        fileName = "New " + nameof(RaccoonShirtThrowingStateConfig),
        menuName = AssetMenuHelper.BossFight_StatesConfigs + nameof(RaccoonShirtThrowingStateConfig))]
    public sealed class RaccoonShirtThrowingStateConfig : ScriptableObject
    {
        [field: SerializeField] public int ShirtsCount { get; private set; }
        [field: SerializeField] public float ThrowRate { get; private set; }
    }
}