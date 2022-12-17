using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace AutumnForest.Other
{
    [RequireComponent(typeof(Camera))]
    public class MainCameraBrain : MonoBehaviour
    {
        //fields
        [SerializeField] private Transform firstFollowTarget;
        [SerializeField] private Transform secondFollowTarget;
        [SerializeField] private float positionLerp = 0.15f;
        private new Camera camera;
        private PostProcessVolume postProcessVolume;

        //unity methods
        private void Awake() => camera = GetComponent<Camera>();
        //private void Start() => FindObjectOfType<BossFightController>().OnBossChange.AddListener(SetTarget);
        private void LateUpdate()
        {
            if (firstFollowTarget != null && secondFollowTarget != null)
                transform.position = GetPosition();
        }
        //setters like
        public void SetTargets(GameObject newFirstTarget = null, GameObject newSecondTarget = null) 
        {
            if(newFirstTarget != null) firstFollowTarget = newFirstTarget.transform;
            if(newSecondTarget != null) secondFollowTarget = newSecondTarget.transform;
        }
        public PostProcessProfile GetPostProcessProfile() => postProcessVolume.profile;
        public void SetLerp(float newLerp) => positionLerp = newLerp;
        public void ChangeOrthographicSize(float toSize, float speed = 0.01f)
        {
            StartCoroutine(Change());

            IEnumerator Change()
            {
                float sizeIncreasing = 0.1f;
                int cycles = (int)((toSize - camera.orthographicSize) / sizeIncreasing);

                for(int i = 0; i < cycles; i++)
                {
                    yield return new WaitForSeconds(speed);
                    camera.orthographicSize += sizeIncreasing; 
                }
            }
        }
        
        //other methods
        private Vector3 GetPosition()
        {
            return new Vector3(Mathf.Lerp(firstFollowTarget.transform.position.x, secondFollowTarget.position.x, positionLerp),
                Mathf.Lerp(firstFollowTarget.transform.position.y, secondFollowTarget.position.y, positionLerp), -10f);
        }
    }
}