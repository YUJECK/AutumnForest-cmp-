using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private Transform secondTarget;
    [SerializeField] private float lerp;
    private Vector3 targetPos;

    public void SetTarget(GameObject newTarget) => followTarget = newTarget.transform;

    void LateUpdate()
    {
        if (followTarget != null && followTarget.transform.position != targetPos)
        {
            targetPos = new Vector3(Mathf.Lerp(followTarget.transform.position.x, secondTarget.position.x, lerp), 
                Mathf.Lerp(followTarget.transform.position.y, secondTarget.position.y, lerp), -10f);
            transform.position = targetPos;
        }
    }
}