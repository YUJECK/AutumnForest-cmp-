using AutumnForest.Other;
using System;
using UnityEngine;

namespace AutumnForest.Projectiles
{
    [RequireComponent(typeof(MonoRotator))]
    public class Shooting : MonoBehaviour
    {
        [field: SerializeField] public Transform FirePoint { get; private set; }
        public TransformRotation TransformRotation { get; private set; }

        public event Action<Rigidbody2D> OnShoot;

        private void Start() => TransformRotation = GetComponent<MonoRotator>().TransfromRotation;

        public void ShootWithInstantiate(Rigidbody2D projectile, float speed, float shootOffset, ForceMode2D forceMode2D = ForceMode2D.Impulse)
        {
            if (FirePoint != null)
            {
                Rigidbody2D newProjectile = Instantiate(projectile, FirePoint.position, FirePoint.rotation);
                newProjectile.transform.Rotate(new Vector3(0, 0, shootOffset));
                newProjectile.AddForce(newProjectile.transform.up * speed, forceMode2D);

                OnShoot?.Invoke(newProjectile);
            }
            else if (FirePoint == null) throw new NullReferenceException(nameof(FirePoint));
            else if (projectile == null) throw new NullReferenceException(nameof(projectile));
        }
        public void ShootWithoutInstantiate(Rigidbody2D projectile, float speed, float shootOffset, bool replace, ForceMode2D forceMode2D = ForceMode2D.Impulse)
        {
            if (FirePoint != null && projectile != null)
            {
                if (replace)
                {
                    projectile.transform.position = FirePoint.position;
                    projectile.transform.rotation = FirePoint.rotation;
                }
                projectile.transform.Rotate(new Vector3(0, 0, shootOffset));
                projectile.AddForce(projectile.transform.up * speed, forceMode2D);

                OnShoot?.Invoke(projectile);
            }
            else if (FirePoint == null) throw new NullReferenceException(nameof(FirePoint));
            else if (projectile == null) throw new NullReferenceException(nameof(projectile));
        }
    }
}