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
            GameManager.MainCamera.orthographicSize = 6f;
            Following cameraFollowing = GameManager.MainCamera?.GetComponent<Following>();

            if (cameraFollowing != null && raccoon != null)
                cameraFollowing.followTarget = raccoon; 
            else Debug.LogError("Following script doesnt set to camera");
            if (log != null) log.SetActive(true);
        }
        public override void EndBossFight()
        {
            onBossFightEnds.Invoke();
            GameManager.MainCamera.orthographicSize = 3f;
            Following cameraFollowing = GameManager.MainCamera?.GetComponent<Following>();

            if (cameraFollowing != null && raccoon != null)
                cameraFollowing.followTarget = GameManager.Player.gameObject;
            else Debug.LogError("Following script doesnt set to camera");
            if (log != null) log.SetActive(false);
        }
    }
}