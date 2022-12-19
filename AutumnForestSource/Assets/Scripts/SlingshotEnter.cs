using UnityEngine;

namespace AutumnForest.Other
{
    public class SlingshotEnter : OnTriggerEnterEvent
    {
        [SerializeField] private float lerp;
        [SerializeField] private float cameraSize;
        [SerializeField] private float timeScale;
        [SerializeField] private Sprite cursor;   

        protected override void OnEnterTrigger()
        {
            ServiceLocator.GetService<MainCameraBrain>().SetLerp(0.6f);
            ServiceLocator.GetService<MainCameraBrain>().ChangeOrthographicSize(4);

            Time.timeScale = 0.7f;
            FindObjectOfType<Cursor>().SetCursorIcon(cursor);
        }
    }
}