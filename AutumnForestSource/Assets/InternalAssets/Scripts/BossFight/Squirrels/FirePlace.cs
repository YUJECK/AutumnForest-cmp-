using System;
using UnityEngine;

namespace AutumnForest.BossFight.Squirrels
{
    public sealed class SquirrelFirePlace
    {
        public event Action OnCasted;

        public void CastFirePlace(Vector2 position, float radius)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(position, radius);

            for(int i = 0; i < hits.Length; i++)
            {
                if (hits[i].TryGetComponent(out IFireable fireable))
                    fireable.Fire();
            }
            OnCasted?.Invoke();
        }
    }
}