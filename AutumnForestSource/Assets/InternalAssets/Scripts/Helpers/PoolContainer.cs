using AutumnForest.BossFight;
using AutumnForest.Projectiles;
using System;

namespace AutumnForest.Helpers
{
    public class SomePoolsContainer
    {
        public ObjectPool<Projectile> AcornPool { get; }
        public ObjectPool<Projectile> ConePool { get; }
        public ObjectPool<AcornHeal> AcornHealPool { get; }
        public ObjectPool<Projectile> TargetedSwordPool { get; }
        public ObjectPool<Projectile> DefaultSwordPool { get; }


        public SomePoolsContainer(Projectile Acorn, Projectile Cone, AcornHeal acornHeal, Projectile defaultSword, Projectile targetedSword)
        {
            AcornPool = new(Acorn, GlobalServiceLocator.GetService<ContainerHelper>().ProjectileContainer, 15, true);
            ConePool = new(Cone, GlobalServiceLocator.GetService<ContainerHelper>().ProjectileContainer, 20, true);
            AcornHealPool = new(acornHeal, GlobalServiceLocator.GetService<ContainerHelper>().OtherContainer, 20, true);
            DefaultSwordPool = new(defaultSword, GlobalServiceLocator.GetService<ContainerHelper>().ProjectileContainer, 10, true);
            TargetedSwordPool = new(targetedSword, GlobalServiceLocator.GetService<ContainerHelper>().ProjectileContainer, 12, true);
        }
    }
}