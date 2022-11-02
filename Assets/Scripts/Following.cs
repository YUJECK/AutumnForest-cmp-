using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    void FixedUpdate()
    {
        if (targetTransform != null && transform.position != targetTransform.position)
            transform.position = new Vector3 (targetTransform.position.x, targetTransform.position.y, -100f);
    }
}