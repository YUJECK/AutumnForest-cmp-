using AutumnForest;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InteractionField))]
public class Slingshot : MonoBehaviour
{
    //fields
    [SerializeField] private Transform target;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Text culldownText;
    private bool canShoot = true;
    [SerializeField] private PointRotation pointRotation;

    //methods
    public void ChangeTarget(GameObject newTarget) 
    {
        target = newTarget.transform;
        pointRotation.SetTarget(newTarget);
    }
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

    //unity methods
    private void Start()
    {
        FindObjectOfType<MafiaFightController>().OnBossChange.AddListener(ChangeTarget);
        GetComponent<InteractionField>().OnKeyDown.onKeyDown.AddListener(Shoot);
    }
}