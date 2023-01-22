using AutumnForest.Helpers;
using AutumnForest.Other;
using Cinemachine;
using UnityEngine;

namespace AutumnForest.BossFight.Slingshot
{
    [RequireComponent(typeof(Slingshot))]
    [RequireComponent(typeof(Collider2D))]
    public sealed class SlingshotInteractive : MonoBehaviour, IInteractive
    {
        [SerializeField] private Sprite slingshotCursor;
        [SerializeField] private Sprite cursorDefault;

        private bool currentlyZoomed = false;
        private Slingshot slingshot;

        private void Awake() => slingshot = GetComponent<Slingshot>();
        private void OnEnable() => slingshot.OnShoot += Distance;
        private void OnDisable() => slingshot.OnShoot -= Distance;
        
        // мне если честно не особо нравится такое решение отключения рогатки,
        // но я хз что еще придумать(мне лень) 
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(TagHelper.PlayerTag))
            {
                slingshot.DisableSlingshot();
                Distance();
            }
        }

        public void Interact()
        {
            Zoom();
            slingshot.EnableSlingshot();
        }

        private void Zoom()
        {
            if(!currentlyZoomed)
            {
                GlobalServiceLocator.GetService<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
                GlobalServiceLocator.GetService<VirtualCameraHelper>().SlingshotCamera.gameObject.SetActive(true);
            
                FindObjectOfType<Cursor>().SetCursorIcon(slingshotCursor);
                currentlyZoomed = true;
            }
        }
        private void Distance()
        {
            if(currentlyZoomed)
            {
                GlobalServiceLocator.GetService<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
                GlobalServiceLocator.GetService<VirtualCameraHelper>().BossfightCamera.gameObject.SetActive(true);

                FindObjectOfType<Cursor>().SetCursorIcon(cursorDefault);
                currentlyZoomed = false;
            }
        }
    }
}