using AutumnForest.Helpers;
using System.Collections.Generic;
using UnityEngine;

namespace CreaturesAI
{
    public sealed class Target : MonoBehaviour, ICreatureComponent
    {
        public sealed class TargetComparator : IComparer<Target>
        {
            public int Compare(Target x, Target y)
            {
                if (x.Priority < y.Priority) return 1;
                else if (x.Priority > y.Priority) return -1;

                return 0;
            }
        }

        [SerializeField] private int priority = 1;
        public int Priority => priority;
    }
}