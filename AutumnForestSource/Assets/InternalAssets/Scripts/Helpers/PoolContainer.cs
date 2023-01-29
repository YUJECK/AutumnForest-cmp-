using AutumnForest.BossFight;
using AutumnForest.Projectiles;
using System;
using UnityEngine;

namespace AutumnForest.Helpers
{
    [Serializable]
    public class SomePoolsContainer
    {
        public ObjectPool<Projectile> AcornPool { get; }
        public ObjectPool<Projectile> ConePool { get; }
        public ObjectPool<AcornHeal> AcornHealPool { get; }

        //public ObjectPool<FireSquirrel> fireSquirrelPool { get; }

        public SomePoolsContainer(Projectile Acorn, Projectile Cone, AcornHeal acornHeal)
        {
            //тут еще должны быть проверки на нал но мне лень +в пуле уже есть такая

            AcornPool = new(Acorn, GlobalServiceLocator.GetService<ContainerHelper>().ProjectileContainer, 15, true);
            ConePool = new(Cone, GlobalServiceLocator.GetService<ContainerHelper>().ProjectileContainer, 20, true);
            AcornHealPool = new(acornHeal, GlobalServiceLocator.GetService<ContainerHelper>().OtherContainer, 20, true);
        }


        //тут еще мечи всякие будут 
    }
}