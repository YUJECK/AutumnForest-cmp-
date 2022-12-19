using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.BossFight
{
    [RequireComponent(typeof(InteractionField))]
    public class SlingshotShoot : MonoBehaviour
    {
        //fields
        [SerializeField] private Transform target;
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform firePoint;
        [SerializeField] private Text culldownText;
        private bool canShoot = true;
        [SerializeField] private PointRotation pointRotation;

        //unity methods
        private void Start()
        {
            //FindObjectOfType<BossFightController>().OnBossChange.AddListener(ChangeTarget);
            GetComponent<InteractionField>().OnKeyDown.OnKeyDown.AddListener(Shoot);
        }

        //methods
        public void ChangeTarget(GameObject newTarget)
        {
            target = newTarget.transform;
            pointRotation.SetTarget(newTarget);
        }
        public void Shoot()
        {
            if (canShoot)
            {
                Instantiate(projectile, firePoint.position, firePoint.rotation);
                StartCoroutine(Culldown());
            }
        }
        private IEnumerator Culldown()
        {
            canShoot = false;

            for (int i = 0; i < 5; i++)
            {
                culldownText.text = (5 - i).ToString();
                yield return new WaitForSeconds(1f);
            }

            culldownText.text = "";
            canShoot = true;
        }
    }
}