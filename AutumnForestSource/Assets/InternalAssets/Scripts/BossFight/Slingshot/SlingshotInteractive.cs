using AutumnForest.Helpers;
using AutumnForest.Other;
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Slingshot
{
    public sealed class SlingshotInteractive : MonoBehaviour, IInteractive
    {
        [SerializeField] private float lerpOnZoom;
        [SerializeField] private Sprite slingshotCursor;

        [SerializeField] private float lerpDefault;
        [SerializeField] private Sprite cursorDefault;

        private Slingshot slingshotShoot;
        
        public event Action OnInteract;

        private void OnEnable()
        {
            slingshotShoot.OnShoot += Distance;
        }

        public void Interact()
        {
            Zoom();
            slingshotShoot.EnableSlingshot();
        }

        private void Zoom()
        {
            GlobalServiceLocator.GetService<MainCameraBrain>().SetLerp(lerpOnZoom);
            GlobalServiceLocator.GetService<MainCameraBrain>().ChangeOrthographicSize(CameraSizeHelper.Slingshot);

            FindObjectOfType<Cursor>().SetCursorIcon(slingshotCursor);
        }
        private void Distance()
        {
            GlobalServiceLocator.GetService<MainCameraBrain>().SetLerp(lerpDefault);
            GlobalServiceLocator.GetService<MainCameraBrain>().ChangeOrthographicSize(CameraSizeHelper.Slingshot);

            FindObjectOfType<Cursor>().SetCursorIcon(cursorDefault);
        }
    }
}