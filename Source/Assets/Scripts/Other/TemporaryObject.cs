using System.Collections;
using UnityEngine;

namespace AutumnForest
{
    public class TemporaryObject : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 1f;

        private IEnumerator Dead()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }
        private void Start() => StartCoroutine(Dead());
    }
}