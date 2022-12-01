using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest
{
    [RequireComponent(typeof(AreaHit))]
    public class ChestnutBomb : MonoBehaviour
    {
        private int damage;
        private AreaHit areaHit;
        private void Start() => StartCoroutine(Exploit());
    
        private IEnumerator Exploit()
        {
            yield return new WaitForSeconds(1);
            areaHit.Hit(damage);
        }
    }
}