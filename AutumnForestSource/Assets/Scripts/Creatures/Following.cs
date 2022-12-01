using AutumnForest;
using UnityEngine;

public class MainCameraBrain : MonoBehaviour
{
    [SerializeField] private Transform firstFollowTarget;
    [SerializeField] private bool lerping = false;
    [SerializeField] private Transform secondFollowTarget; //i need to code editor script for disabling/enabaling this fields
    [SerializeField] private float lerp;
    private Vector3 targetPos;
    
    //some methods
    public void SetTarget(GameObject newTarget) => firstFollowTarget = newTarget.transform;
    private Vector3 GetPosition(Transform target1, Transform target2)
    {
        return new Vector3(Mathf.Lerp(firstFollowTarget.transform.position.x, secondFollowTarget.position.x, lerp),
            Mathf.Lerp(firstFollowTarget.transform.position.y, secondFollowTarget.position.y, lerp), -10f);
    }
    private Vector3 GetPosition(Transform target) => new Vector3(target.position.x, target.position.y, -10f);

    //unity methods
    private void Start()
    {
        FindObjectOfType<MafiaFightController>().OnBossChange.AddListener(SetTarget);
    }
    private void LateUpdate()
    {
        if (lerping)
        {
            if (firstFollowTarget != null && secondFollowTarget != null)
                targetPos = GetPosition(firstFollowTarget, secondFollowTarget);
        }
        else if (firstFollowTarget != null) targetPos = GetPosition(firstFollowTarget);

        transform.position = targetPos;
    }
}