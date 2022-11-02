using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Slingshot : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Text culldownText;
    private bool canShoot = true;

    public void Shoot()
    {
        if(canShoot)
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