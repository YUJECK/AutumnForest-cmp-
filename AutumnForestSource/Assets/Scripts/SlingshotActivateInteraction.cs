using AutumnForest.Other;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.BossFight
{
    public class SlingshotActivateInteraction : MonoBehaviour, IInteractive
    {
        [SerializeField] private float lerp = 0.6f;
        [SerializeField] private float cameraSize = 4;
        [SerializeField] private float timeScale = 0.7f;
        [SerializeField] private Sprite cursor;

        public UnityEvent OnInteract { get; set; } = new();

        public void Interact()
        {
            ServiceLocator.GetService<MainCameraBrain>().SetLerp(lerp);
            ServiceLocator.GetService<MainCameraBrain>().ChangeOrthographicSize(cameraSize);

            Time.timeScale = timeScale;
            FindObjectOfType<Cursor>().SetCursorIcon(cursor);
            FindObjectOfType<SlingshotShoot>().ActivateSlingshot();
        }
    }
}