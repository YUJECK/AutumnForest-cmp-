using System;
using UnityEngine;

namespace AutumnForest.BossFight
{
    [Serializable]
    public sealed class SpawnPlace
    {
        int layer = 0 << 2;

        [field: SerializeField] public Vector2 LeftDownCorner { get; private set; }
        [field: SerializeField] public Vector2 RightUpCorner { get; private set; }

        public SpawnPlace(Vector2 leftDownCorner, Vector2 rightUpCorner)
        {
            this.LeftDownCorner = leftDownCorner;
            this.RightUpCorner = rightUpCorner;
        }

        public Vector2 GetPosition()
        {
            while (true)
            {
                if(!ContaintsColliders(GetHits(out Vector2 position)))
                    return position;
            }
        }

        private RaycastHit2D[] GetHits(out Vector2 position)
        {
            position = new Vector2(UnityEngine.Random.Range(LeftDownCorner.x, RightUpCorner.x),
                                          UnityEngine.Random.Range(LeftDownCorner.y, RightUpCorner.y));
            return Physics2D.RaycastAll(position, Vector2.zero, ~layer);
        }
        private bool ContaintsColliders(RaycastHit2D[] hits)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider != null)
                    return true;
            }

            return false;
        }
    }
}