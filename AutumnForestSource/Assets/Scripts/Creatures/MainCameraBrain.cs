using System.Collections;
using System.Threading.Tasks;
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
        [SerializeField] private PostProcessVolume postProcessVolume;
        private new Camera camera;

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
            if (newFirstTarget != null) firstFollowTarget = newFirstTarget.transform;
            if (newSecondTarget != null) secondFollowTarget = newSecondTarget.transform;
        }
        public PostProcessProfile GetPostProcessProfile() => postProcessVolume.profile;
        public void SetLerp(float newLerp) => positionLerp = newLerp;
        public async void ChangeOrthographicSize(float toSize)
        {
            float startSize = camera.orthographicSize;

            for (float i = 0f; camera.orthographicSize != toSize; i += 0.02f)
            {
                camera.orthographicSize = Mathf.Lerp(startSize, toSize, i);
                await Task.Delay(1);
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