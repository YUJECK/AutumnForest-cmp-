using AutumnForest.BossFight.Squirrels;
using AutumnForest.Projectiles;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace AutumnForest.Assets.InternalAssets.Scripts
{
    public sealed class SquirrelCatscene : Squirrel
    {
        [SerializeField] private Shooting shooting;
        [SerializeField] private Animator animator;
        [SerializeField] private PitchedAudio shotAudio;

        [SerializeField] private Projectile acorn;
        [SerializeField] private string shotAnimation;

        private void Start()
        {
            Shooting(this.GetCancellationTokenOnDestroy());
        }

        private async void Shooting(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (gameObject.activeInHierarchy)
                {
                    shooting.ShootWithInstantiate(acorn.Rigidbody2D, 10, UnityEngine.Random.Range(-40, 40), ForceMode2D.Impulse);
                    
                    animator.Play(shotAnimation);
                    shotAudio.Play();
                }
                
                await UniTask.Delay(TimeSpan.FromSeconds(3f));
            }
        }
    }
}