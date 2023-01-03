using CreaturesAI.CombatSkills;
using System.Collections;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    [CreateAssetMenu]
    public class TripleShootPattern : ShootingPattern
    {
        //variables
        [SerializeField] private GameObject projectile;
        [SerializeField] private int projectilesCount = 3;
        [SerializeField] private float shootingRate = 0.5f;
        [SerializeField] private float shootingSpread = 15f;

        public override IEnumerator Pattern(Shooting shooting)
        {
            for (int i = 0; i < projectilesCount; i++)
            {
                shooting.ShootWithInstantiate(projectile, 10, Random.Range(0, shootingSpread), 0f, ForceMode2D.Impulse);
                yield return new WaitForSeconds(shootingRate);
            }
            
            OnPatternEnd.Invoke();
        }
    }
}