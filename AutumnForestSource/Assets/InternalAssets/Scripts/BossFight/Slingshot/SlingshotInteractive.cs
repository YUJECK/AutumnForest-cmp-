using AutumnForest.Helpers;
using AutumnForest.Other;
using Cinemachine;
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Slingshot
{
    [RequireComponent(typeof(Slingshot))]
    public sealed class SlingshotInteractive : MonoBehaviour, IInteractive
    {
        [SerializeField] private Sprite slingshotCursor;
        [SerializeField] private Sprite cursorDefault;

        private Slingshot slingshot;

        private void Awake() => slingshot = GetComponent<Slingshot>();
        private void OnEnable() => slingshot.OnShoot += Distance;
        private void OnDisable() => slingshot.OnShoot -= Distance;

        public void Interact()
        {
            Zoom();
            slingshot.EnableSlingshot();
        }

        private void Zoom()
        {
            GlobalServiceLocator.GetService<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
            GlobalServiceLocator.GetService<VirtualCameraHelper>().SlingshotCamera.gameObject.SetActive(true);
            
            FindObjectOfType<Cursor>().SetCursorIcon(slingshotCursor);
        }
        private void Distance()
        {
            GlobalServiceLocator.GetService<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
            GlobalServiceLocator.GetService<VirtualCameraHelper>().BossfightCamera.gameObject.SetActive(true);

            FindObjectOfType<Cursor>().SetCursorIcon(cursorDefault);
        }
    }
}