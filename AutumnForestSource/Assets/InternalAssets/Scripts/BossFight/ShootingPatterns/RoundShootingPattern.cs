using CreaturesAI.CombatSkills;
using System.Collections;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    [CreateAssetMenu]
    public class RoundShootingPattern : ShootingPattern
    {
        [SerializeField] private GameObject cone;

        public override IEnumerator Pattern(Shooting shooting)
        {
            shooting.StopPointRotation(true);

            for (int i = 1; i < 37; i++)
            {
                shooting.ShootWithInstantiate(cone, 7, 0, i * 30, ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.05f);
            }

            shooting.StopPointRotation(false);

            OnPatternEnd.Invoke();
        }
    }
}