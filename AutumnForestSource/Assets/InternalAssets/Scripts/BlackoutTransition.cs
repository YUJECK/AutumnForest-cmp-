using UnityEngine;

namespace AutumnForest
{
    public class BlackoutTransition : MonoBehaviour
    {
        [SerializeField] private Animator blackout;
        [SerializeField] private string blackoutAnimationName = "BlackoutBegin";

        public void StartBlackout() => blackout.Play(blackoutAnimationName);
    }
}