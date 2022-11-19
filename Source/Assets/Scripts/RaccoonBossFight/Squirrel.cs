using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Squirrel : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firePoint;
    private Animator animator;

    private IEnumerator Shooting()
    {
        while(true)
        {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(2f);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Shooting());
    }
}