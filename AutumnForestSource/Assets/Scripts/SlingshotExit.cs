using UnityEngine;

namespace AutumnForest.Other
{
    public class SlingshotExit : OnTriggerExitEvent
    {
        [SerializeField] private float lerp;
        [SerializeField] private float cameraSize;
        [SerializeField] private float timeScale;
        [SerializeField] private Sprite cursor;

        protected void OnTriggerExit()
        {
            ServiceLocator.GetService<MainCameraBrain>().SetLerp(lerp);
            ServiceLocator.GetService<MainCameraBrain>().ChangeOrthographicSize(cameraSize);

            Time.timeScale = timeScale;
            //FindObjectOfType<Cursor>().SetCursorIcon(cursor);
        }
    }
}