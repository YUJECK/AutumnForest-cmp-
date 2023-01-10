using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest.Extensions
{
    public static class AnimatorExtension
    {
        public async static UniTask WaitForEndOfCurrentClip(this Animator animator, float delay)
        {
            float uniTaskDelay = animator.GetCurrentAnimatorStateInfo(0).length - delay;
            if (uniTaskDelay < 0) uniTaskDelay = 0f;

            await UniTask.Delay(TimeSpan.FromSeconds(uniTaskDelay));
        }
    }
}