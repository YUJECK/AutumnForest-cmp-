using UnityEngine;

public class PointRotation : MonoBehaviour
{
    private float currentAngle;
    [SerializeField] private Transform targetObject;
    [SerializeField] private bool useAsPlayer;


    private void Start()
    {
        if(useAsPlayer)
            targetObject = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (targetObject != null)
        {
            Vector2 direction = targetObject.position - transform.position;
            currentAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
        }
    }
}