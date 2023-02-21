using AutumnForest.Projectiles;
using UnityEngine;

namespace AutumnForest.BossFight.States
{
    [CreateAssetMenu(menuName = AssetMenuHelper.BossFight_StatesConfigs + nameof(RandomShotStateConfig), fileName = "New " + nameof(RandomShotStateConfig))]
    public sealed class RandomShotStateConfig : ScriptableObject
    {
        [field: SerializeField] public Projectile ProjectilePrefab { get; private set; }
        [field: SerializeField] public int ProjectilesCount { get; private set; }
        [field: SerializeField] public float ProjectileForce { get; private set; }
        [field: SerializeField] public float ShotMinimumRate { get; private set; }
        [field: SerializeField] public float ShotMaximumRate { get; private set; }
    }
}