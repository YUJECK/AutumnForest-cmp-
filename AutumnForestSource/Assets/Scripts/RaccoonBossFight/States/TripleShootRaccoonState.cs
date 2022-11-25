using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    public class TripleShootRaccoonState : ShootingPattern
    {
        [SerializeField] private GameObject chestnut;
        [SerializeField] private float shootingRate = 0.5f;
        [SerializeField] private float shootingSpread = 25f;

        public override IEnumerator Pattern(Shooting shooting)
        {
            for (int i = 0; i < 3; i++)
            {
                shooting.Shoot(chestnut, 10, 0f, shootingSpread, ForceMode2D.Impulse);
                yield return new WaitForSeconds(shootingRate);
            }
        }
    }
}