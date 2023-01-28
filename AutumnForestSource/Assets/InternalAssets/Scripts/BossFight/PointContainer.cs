using System;
using UnityEngine;

namespace AutumnForest.BossFight
{
    [Serializable]
    public sealed class PointContainer
    {
        [SerializeField] private Transform[] points;

        public bool Pick(out Transform point)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (!points[i].gameObject.activeInHierarchy)
                {
                    point = points[i];
                    return true;
                }
            }

            point = null;
            return false;
        }
    }
}