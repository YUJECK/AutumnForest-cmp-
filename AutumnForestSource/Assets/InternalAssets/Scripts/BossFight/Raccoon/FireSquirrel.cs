using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace AutumnForest.BossFight.Squirrels
{
    public sealed class FireSquirrel : Squirrel
    {
        [SerializeField] private float radius = 1;
        [SerializeField] private float castRate = 3.5f;

        public SquirrelFirePlace FirePlace { get; private set; } = new();

        private async void Casting(CancellationToken token)
        {
            try
            {
                Debug.Log("Casting");
                
                FirePlace.CastFirePlace(transform.position, radius);
                await UniTask.Delay(TimeSpan.FromSeconds(castRate));
            }
            finally
            {
                Debug.Log("Finally");
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}