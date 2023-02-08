using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.BossFight.Squirrels
{
    public sealed class FireSquirrel : Squirrel
    {
        [SerializeField] private float radius = 1;

        [field: SerializeField] public float CastRate { get; private set; }  = 3.5f;
        public SquirrelFirePlace FirePlace { get; private set; } = new();

        private CancellationTokenSource cancellationToken;

        private void OnEnable()
        {
            cancellationToken = new();
            Casting(cancellationToken.Token);
        }
        private void OnDisable()
        {
            cancellationToken.Cancel();
            cancellationToken.Dispose();
        }

        private async void Casting(CancellationToken token)
        {
            while (true)
            {
                try
                {
                    FirePlace.CastFirePlace(transform.position, radius);
                    await UniTask.Delay(TimeSpan.FromSeconds(CastRate), cancellationToken: token);
                }
                catch
                {
                    return;
                }
            }   
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}