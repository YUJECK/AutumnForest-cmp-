using CreaturesAI.CombatSkills;
using CreaturesAI.Health;
using System.Collections;
using UnityEngine;

namespace AutumnForest.BossFight
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CreatureHealth))]
    public class Squirrel : MonoBehaviour
    {
        //fields
        [SerializeField] private GameObject acornProjectile;
        [SerializeField] private GameObject acornHeal;
        [SerializeField] private Shooting shooting;

        //shooting coroutine
        private IEnumerator Shooting()
        {
            while (true)
            {
                shooting.ShootWithInstantiate(acornProjectile, 10, 0, 0, ForceMode2D.Impulse);
                yield return new WaitForSeconds(2f);
            }
        }

        //unity methods
        private void Awake()
        {
            GetComponent<Health>().OnDie.AddListener(delegate { Instantiate(acornHeal, transform.position, transform.rotation); });
            GetComponent<Health>().OnDie.AddListener(delegate { Destroy(gameObject); });
        }
        private void Start() => StartCoroutine(Shooting());
    }
}