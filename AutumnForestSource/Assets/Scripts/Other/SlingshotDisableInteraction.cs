using AutumnForest.Other;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.BossFight
{
    class SlingshotDisableInteraction : MonoBehaviour, IInteractive
    {
        [SerializeField] private float lerp = 0.15f;
        [SerializeField] private float cameraSize = 6;
        [SerializeField] private float timeScale = 1f;
        [SerializeField] private Sprite cursor;

        public UnityEvent OnInteract { get; set; } = new();

        public void Interact()
        {
            ServiceLocator.GetService<MainCameraBrain>().SetLerp(lerp);
            ServiceLocator.GetService<MainCameraBrain>().ChangeOrthographicSize(cameraSize);

            Time.timeScale = timeScale;
            FindObjectOfType<Cursor>().SetCursorIcon(cursor);
            FindObjectOfType<SlingshotShoot>().DisableSlingshot();
        }
    }
}