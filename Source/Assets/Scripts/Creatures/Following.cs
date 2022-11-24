using UnityEngine;

public class Following : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 targetPos;

    public void SetTarget(GameObject newTarget) => followTarget = newTarget;

    void LateUpdate()
    {
        if (followTarget != null && followTarget.transform.position != targetPos)
        {
            targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, -10f);
            transform.position = targetPos;
        }
    }
}