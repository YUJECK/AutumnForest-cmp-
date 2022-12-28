using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public class TemporaryObject : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 1f;
        public UnityEvent OnDestroy = new();

        private IEnumerator Dead()
        {
            yield return new WaitForSeconds(lifeTime);
            OnDestroy.Invoke();
            Destroy(gameObject);
        }
        private void Start() => StartCoroutine(Dead());
    }
}