using AutumnForest.BossFight;
using AutumnForest.Other;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public class SlingshotActivateInteraction : MonoBehaviour, IInteractive
    {
        [SerializeField] private float lerpOnZoom = 0.6f;
        [SerializeField] private float cameraSizeOnZoom = 4;
        [SerializeField] private float timeScaleOnZoom = 0.7f;
        [SerializeField] private Sprite cursorOnZoom; 

        private UnityEvent onInteract = new();
        public UnityEvent OnInteract { get => onInteract; set => onInteract = value; }

        public void Interact()
        {
            ServiceLocator.GetService<MainCameraBrain>().SetLerp(lerpOnZoom);
            ServiceLocator.GetService<MainCameraBrain>().ChangeOrthographicSize(cameraSizeOnZoom);

            Time.timeScale = timeScaleOnZoom;
            FindObjectOfType<Cursor>().SetCursorIcon(cursorOnZoom);
            FindObjectOfType<SlingshotShoot>().ActivateSlingshot();
        }
    }
}