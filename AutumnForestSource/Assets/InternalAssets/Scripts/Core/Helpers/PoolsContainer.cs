﻿using AutumnForest.BossFight;
using AutumnForest.Projectiles;
using UnityEngine;

namespace AutumnForest.Helpers
{
    [DisallowMultipleComponent]
    public sealed class PoolsContainer : MonoBehaviour
    {
        [SerializeField] private Projectile acorn;
        [SerializeField] private Projectile cone;
        [SerializeField] private AcornHeal acornHeal;
        [SerializeField] private Projectile defaultSword;
        [SerializeField] private Projectile targetedSword;
        [SerializeField] private Shirt shirt;
        [SerializeField] private SwordWanderer swordWanderer;

        public ObjectPool<Projectile> AcornPool { get; private set; }
        public ObjectPool<Projectile> ConePool { get; private set; }
        public ObjectPool<AcornHeal> AcornHealPool { get; private set; }
        public ObjectPool<Projectile> TargetedSwordPool { get; private set; }
        public ObjectPool<Projectile> DefaultSwordPool { get; private set; }
        public ObjectPool<Shirt> ShirtPool { get; private set; }
        public ObjectPool<SwordWanderer> SwordWandererPool { get; private set; }

        private void Start()
        {
            AcornPool = new(acorn, GlobalServiceLocator.GetService<ContainerHelper>().ProjectileContainer, 15, true);
            ConePool = new(cone, GlobalServiceLocator.GetService<ContainerHelper>().ProjectileContainer, 20, true);
            AcornHealPool = new(acornHeal, GlobalServiceLocator.GetService<ContainerHelper>().OtherContainer, 20, true);
            DefaultSwordPool = new(defaultSword, GlobalServiceLocator.GetService<ContainerHelper>().ProjectileContainer, 10, true);
            TargetedSwordPool = new(targetedSword, GlobalServiceLocator.GetService<ContainerHelper>().ProjectileContainer, 12, true);
            ShirtPool = new(shirt, GlobalServiceLocator.GetService<ContainerHelper>().ProjectileContainer, 12, true);
            SwordWandererPool = new(swordWanderer, GlobalServiceLocator.GetService<ContainerHelper>().ProjectileContainer, 6, true);
        }
    }
}