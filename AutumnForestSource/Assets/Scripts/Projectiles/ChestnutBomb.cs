using System.Collections;
using System.Drawing;
using UnityEngine;

namespace AutumnForest
{
    [RequireComponent(typeof(AreaHit))]
    public class ChestnutBomb : MonoBehaviour
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
        private void Start() => StartCoroutine(Exploit());

        //methods
        private IEnumerator Exploit()
        {
            yield return new WaitForSeconds(timeToExpoit);
            areaHit.Hit(damage);

            Instantiate(exploitPrefab, transform.position, transform.rotation);

            foreach (Transform point in spikesSpawnPoints)
                Instantiate(spikePrefab, point.position, point.rotation);

            Destroy(gameObject);
        }
    }
}