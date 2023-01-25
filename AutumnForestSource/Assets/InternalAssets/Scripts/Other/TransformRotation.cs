using Cysharp.Threading.Tasks;
using System;
using Unity.Profiling;
using UnityEngine;

public sealed class TransformRotation
{
    public enum RotateType
    {
        ByTarget,
        Around
    }

    public float Coefficient { get; set; } = 1f;
    public RotateType RotationType { get; set; }

    public bool Enabled { get; private set; } = true;

    private Transform transform;
    private Transform target;

    private event Action<float> OnAngleCalculated;

    public TransformRotation(Transform transform, Transform target, float coefficient, RotateType defaultType)
    {
        this.Coefficient = coefficient;
        this.transform = transform;
        this.target = target;

        this.RotationType = defaultType;

        RotationLoop();
    }

    public void Enable() => Enabled = true;
    public void Disable() => Enabled = false;
    
    private float GetAngle()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        OnAngleCalculated?.Invoke(angle);

        Debug.Log(angle);

        return Coefficient * angle;
    }
    private async void RotationLoop()
    {
        while (true)
        {
            if (Enabled)
            {
                switch (RotationType)
                {
                    case RotateType.ByTarget:
                        transform.rotation = Quaternion.Euler(0, 0, GetAngle());
                        break;
                    case RotateType.Around:
                        transform.Rotate(0, 0, 0.5f * Coefficient);
                        break;
                }
            }

            await UniTask.WaitForFixedUpdate();
        }
    }
}