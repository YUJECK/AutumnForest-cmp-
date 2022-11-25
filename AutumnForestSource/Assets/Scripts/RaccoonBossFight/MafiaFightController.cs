using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public class MafiaFightController : BossFightController
    {
        [SerializeField] private GameObject raccoon;
        [SerializeField] private GameObject fox;
        [SerializeField] private GameObject log;
        public UnityEvent<GameObject> OnBossChange = new UnityEvent<GameObject>();

        //methods
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
        public void BossChangeToFox()
        {
            OnBossChange.Invoke(fox);

            //maybe something else
        }

        //unity methods
        private void Start() => OnBossChange.Invoke(raccoon);
    }
}