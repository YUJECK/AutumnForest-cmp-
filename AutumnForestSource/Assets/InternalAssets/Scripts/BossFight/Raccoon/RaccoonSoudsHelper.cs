using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public sealed class RaccoonSoudsHelper : MonoBehaviour
    {
        [field: SerializeField] public AudioSource LoopedThrowSound { get; private set; }
        [field: SerializeField] public PitchedAudio ThrowSound { get; private set; }
    }
}