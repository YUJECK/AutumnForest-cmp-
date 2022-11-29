using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    [CreateAssetMenu]
    public class RoundShootingPattern : ShootingPattern
    {
        [SerializeField] private GameObject cone;

        public override IEnumerator Pattern(Shooting shooting)
        {
            shooting.StopPointRotation(true);

            for (int i = 0; i < 36; i++)
            {
                Debug.Log("dsfds");
                shooting.ShootWithInstantiate(cone, 7, 0, i * 30, ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.05f);
            }

            shooting.StopPointRotation(false);

            OnPatternEnd.Invoke();
        }
    }
}