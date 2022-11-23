using CreaturesAI;
using UnityEngine;

namespace AutumnForest
{
    public class RaccoonFightController : BossFightController
    {
        [SerializeField] private GameObject raccoon;
        [SerializeField] private GameObject log;

        public override void StartBossFight()
        {
            onBossFightBegins.Invoke();
            ObjectList.MainCamera.orthographicSize = 6f;
            Following cameraFollowing = ObjectList.MainCamera.GetComponent<Following>();

            if (cameraFollowing != null && raccoon != null)
                cameraFollowing.followTarget = raccoon; 
            else Debug.LogError("Following script doesnt set to camera");
            if (log != null) log.SetActive(true);
        }
        public override void EndBossFight()
        {
            onBossFightEnds.Invoke();
            ObjectList.MainCamera.orthographicSize = 3f;
            Following cameraFollowing = ObjectList.MainCamera.GetComponent<Following>();

            if (cameraFollowing != null && raccoon != null)
                cameraFollowing.followTarget = ObjectList.Player.gameObject;
            else Debug.LogError("Following script doesnt set to camera");
            if (log != null) log.SetActive(false);
        }
    }
}