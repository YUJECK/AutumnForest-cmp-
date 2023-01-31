using System.Collections;
using UnityEngine;

namespace AutumnForest.Projectiles
{
    [RequireComponent(typeof(AreaHit))]
    public class ChestnutBomb : Projectile
    {
        //fields
        [SerializeField] private int damage;
        [SerializeField] private float timeToExpoit = 1f;
        private AreaHit areaHit;
        [SerializeField] private GameObject spikePrefab;
        [SerializeField] private GameObject exploitPrefab;
        [SerializeField] private Transform[] spikesSpawnPoints;

        //unity methods
        private void Awake() => areaHit = GetComponent<AreaHit>();
        private void Start() => StartCoroutine(StartExploit());
        private void OnCollisionEnter2D(Collision2D collision) => Exploit();

        //methods
        private IEnumerator StartExploit()
        {
            yield return new WaitForSeconds(timeToExpoit);
            Exploit();
        }
        private void Exploit()
        {
            areaHit.Hit(damage);

            Instantiate(exploitPrefab, transform.position, transform.rotation);

            foreach (Transform point in spikesSpawnPoints)
                Instantiate(spikePrefab, point.position, point.rotation);

            Destroy(gameObject);
        }
    }
}