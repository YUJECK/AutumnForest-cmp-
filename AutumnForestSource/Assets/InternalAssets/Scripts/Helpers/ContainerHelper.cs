using UnityEngine;

namespace AutumnForest.Helpers
{
    public sealed class ContainerHelper
    {

        public Transform ProjectileContainer { get; private set; }
        public Transform CreatureContainer { get; private set; }
        public Transform OtherContainer { get; private set; }
        
        public ContainerHelper(Transform projectileContainer, Transform creatureContainer, Transform otherContainer)
        {
            ProjectileContainer = projectileContainer;
            CreatureContainer = creatureContainer;
            OtherContainer = otherContainer;
        }
    }
}