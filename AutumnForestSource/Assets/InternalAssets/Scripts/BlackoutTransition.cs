using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest
{
    public class BlackoutTransition : MonoBehaviour
    {
        [SerializeField] private Animator blackout;
        [SerializeField] private string blackoutAnimationName = "BlackoutBegin";

        public async UniTask StartBlackout()
        {
            blackout.Play(blackoutAnimationName);

            await UniTask.Delay(TimeSpan.FromSeconds(0.45));
        }
    }
}