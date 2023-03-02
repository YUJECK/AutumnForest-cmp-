using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest
{
    public static class AudioSourceExtensions
    {
        public static async UniTask StopSmoothly(this AudioSource audioSource)
        {
            while (audioSource.volume > 0)
            {
                audioSource.volume -= 0.05f;
                await UniTask.Delay(TimeSpan.FromSeconds(0.075f));
            }
        }
    }
}