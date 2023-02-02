using AutumnForest.Projectiles;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public sealed class Cone : Projectile, IFireable
    {
        [SerializeField] private GameObject fireEffect;

        public bool Fired { get; private set; }

        public void Fire()
        {
            if (!Fired)
            {
                damage += 3;
                fireEffect.SetActive(true);
            }
            //типо сгорает
            else gameObject.SetActive(false);
        }
    }
}