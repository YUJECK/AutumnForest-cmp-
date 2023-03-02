using AutumnForest.Health;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public sealed class BossFightUIMarker : MonoBehaviour 
    {
        [field: SerializeField] public BossFightHealthBar BossFightHealthBar { get; private set; }
        [field: SerializeField] public SimpleHealthBar PlayerHealthBar { get; private set; }
    }
}