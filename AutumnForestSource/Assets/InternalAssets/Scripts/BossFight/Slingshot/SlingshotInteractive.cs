using AutumnForest.Managers;
using AutumnForest.Other;
using Cinemachine;
using UnityEngine;

namespace AutumnForest.BossFight.Slingshot
{
    [RequireComponent(typeof(Slingshot))]
    [RequireComponent(typeof(Collider2D))]
    public sealed class SlingshotInteractive : MonoBehaviour, IInteractive
    {
        [SerializeField] private Texture2D slingshotCursor;
        [SerializeField] private Texture2D cursorDefault;

        private bool currentlyZoomed = false;
        private Slingshot slingshot;

        private void Awake() => slingshot = GetComponent<Slingshot>();
        private void OnEnable() => slingshot.OnShoot += Distance;
        private void OnDisable() => slingshot.OnShoot -= Distance;

        public void Detect() { }
        public void Interact()
        {
            Zoom();
            slingshot.EnableSlingshot();
        }
        public void DetectionReleased()
        {
            slingshot.DisableSlingshot();
            Distance();
        }

        private void Zoom()
        {
            if (!currentlyZoomed)
            {
                GlobalServiceLocator.GetService<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
                GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToSlingshotCamera();

                FindObjectOfType<CursorManager>().SetCursor(slingshotCursor);
                currentlyZoomed = true;
            }
        }
        private void Distance()
        {
            if (currentlyZoomed)
            {
                GlobalServiceLocator.GetService<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
                GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToPrevious();

                FindObjectOfType<CursorManager>().SetCursor(cursorDefault);
                currentlyZoomed = false;
            }
        }
    }
}