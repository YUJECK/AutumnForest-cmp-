using AutumnForest;
using UnityEngine;

public class MainCameraBrain : MonoBehaviour
{
    [SerializeField] private Transform firstFollowTarget;
    [SerializeField] private Transform secondFollowTarget;
    [SerializeField] private float lerp;
    private Vector3 targetPos;
    
    //some methods
    public void SetTarget(GameObject newTarget) => firstFollowTarget = newTarget.transform;
    private Vector3 GetPosition(Transform target1, Transform target2)
    {
        return new Vector3(Mathf.Lerp(firstFollowTarget.transform.position.x, secondFollowTarget.position.x, lerp),
            Mathf.Lerp(firstFollowTarget.transform.position.y, secondFollowTarget.position.y, lerp), -10f);
    }

    //unity methods
    private void Start() => FindObjectOfType<MafiaFightController>().OnBossChange.AddListener(SetTarget);
    private void LateUpdate()
    {   
        if (firstFollowTarget != null && secondFollowTarget != null)
            targetPos = GetPosition(firstFollowTarget, secondFollowTarget);

        transform.position = targetPos;
    }
}