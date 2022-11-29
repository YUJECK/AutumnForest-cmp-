using UnityEngine;

[RequireComponent(typeof(PointRotation))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    private PointRotation pointRotation;

    public void StopPointRotation(bool active) => pointRotation.StopRotating(active);
    public void ShootWithInstantiate(GameObject projectile, float speed, float shootOffset, float spawnOffset, ForceMode2D forceMode2D)
    {
        if (firePoint != null)
        {
            pointRotation.offset = spawnOffset;
            GameObject newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            newProjectile.transform.Rotate(new Vector3(0, 0, shootOffset));
            Rigidbody2D projectileRigidbody = newProjectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.AddForce(newProjectile.transform.up * speed, forceMode2D);
        }
        else Debug.LogWarning("Fire point is null");
    }
    public void ShootWithoutInstantiate(GameObject projectile, float speed, float shootOffset, float spawnOffset, ForceMode2D forceMode2D)
    {
        if (firePoint != null)
        {
            pointRotation.offset = spawnOffset;
            projectile.transform.rotation = firePoint.rotation;
            projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.up * speed, forceMode2D);
        }
        else Debug.LogWarning("Fire point is null");
    }
    private void Awake() => pointRotation = GetComponent<PointRotation>();
}