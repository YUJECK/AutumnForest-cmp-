using AutumnForest;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.CombatSkills
{
    [RequireComponent(typeof(TriggerChecker))]
    [RequireComponent(typeof(AreaHit))]
    public class Combat : MonoBehaviour
    {
        //serialized variables
        [Header("Damage settings")]
        [SerializeField] private int minimumDamage = 10;
        [SerializeField] private int maximumDamage = 20;
        [Header("Timing settings")]
        [SerializeField] private float attackDelay = 0.5f;
        [SerializeField] private float attackRate = 1f;

        //only private variables
        private TriggerChecker triggerChecker;
        private AreaHit areaHit;

        //events
        [Header("Events")]
        public UnityEvent beforeHitting = new UnityEvent();
        public UnityEvent onHitting = new UnityEvent();

        //getters
        public int Damage => Random.Range(minimumDamage, maximumDamage);
        public TriggerChecker TriggerChecker => triggerChecker;

        //public methods
        public void StartAttackingConstantly() => StartCoroutine(ConstantlyAttackingCoroutine());
        public void StopAttackingConstantly() => StopCoroutine(ConstantlyAttackingCoroutine());

        //private methods
        private IEnumerator ConstantlyAttackingCoroutine()
        {
            while (true)
            {
                beforeHitting.Invoke();
                yield return new WaitForSeconds(attackDelay);
                areaHit.Hit(Random.Range(minimumDamage, maximumDamage));
                yield return new WaitForSeconds(attackRate);
            }
        }

        private void Awake()
        {
            triggerChecker = GetComponent<TriggerChecker>();
            areaHit = GetComponent<AreaHit>();
        }

        //unity methods
        private void OnDrawGizmos() => Gizmos.DrawWireSphere(areaHit.transform.position, 1);
    }
}