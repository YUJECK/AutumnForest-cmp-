using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Squirrels
{
    public sealed class FireSquirrel : Squirrel
    {   
        private int radius = 3;
        private float castRate = 3.5f;

        public SquirrelFirePlace FirePlace { get; private set; } = new();

        private void Awake() => CastingFirePlace();
        private async void CastingFirePlace()
        {
            while (true)
            {
                FirePlace.CastFirePlace(transform.position, radius);
                await UniTask.Delay(TimeSpan.FromSeconds(castRate));
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}