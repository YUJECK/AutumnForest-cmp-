using UnityEngine;

namespace AutumnForest.Other
{
    public class SlingshotCameraZoom : MonoBehaviour
    {
        //on zoom
        [Header("Params on zoom")]
        [SerializeField] private IInteractive zoomInteractive;
        [SerializeField] private float lerpOnZoom = 0.6f;
        [SerializeField] private float cameraSizeOnZoom = 4;
        [SerializeField] private float timeScaleOnZoom = 0.7f;
        [SerializeField] private Sprite cursorOnZoom;
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
            ServiceLocator.GetService<MainCameraBrain>().SetLerp(lerpOnZoom);
            ServiceLocator.GetService<MainCameraBrain>().ChangeOrthographicSize(cameraSizeOnZoom);

            Time.timeScale = timeScaleOnZoom;
            FindObjectOfType<Cursor>().SetCursorIcon(cursorOnZoom);
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