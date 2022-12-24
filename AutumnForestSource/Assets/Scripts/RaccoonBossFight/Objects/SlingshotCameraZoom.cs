using UnityEngine;

namespace AutumnForest.Other
{
    [RequireComponent(typeof(InteractionField))]
    public class SlingshotCameraZoom : MonoBehaviour
    {
        //on zoom
        [Header("Params on zoom")]

        [Header("Params on distance")]
        //on distance
        [SerializeField] private IInteractive distanceInteractive;
        [SerializeField] private float lerpOnDistance = 0.6f;
        [SerializeField] private float cameraSizeOnDistance = 4;
        [SerializeField] private float timeScaleOnDistance = 0.7f;
        [SerializeField] private Sprite cursorOnDistance;

        //camera controll methods
        private void Zoom()
        {

        }
        private void Distance()
        {
            ServiceLocator.GetService<MainCameraBrain>().SetLerp(lerpOnDistance);
            ServiceLocator.GetService<MainCameraBrain>().ChangeOrthographicSize(cameraSizeOnDistance);

            Time.timeScale = timeScaleOnDistance;
            FindObjectOfType<Cursor>().SetCursorIcon(cursorOnDistance);
        }
    }
}