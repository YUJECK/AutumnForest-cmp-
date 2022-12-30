using AutumnForest.Helpers;
using AutumnForest.Other;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.BossFight
{
    public class SlingshotActivateInteraction : MonoBehaviour, IInteractive
    {
        [SerializeField] private float lerp = 0.6f;
        [SerializeField] private float timeScale = 0.7f;
        [SerializeField] private Sprite cursor;

        public UnityEvent OnInteract { get; set; } = new();

        public void Interact()
        {
            GlobalServiceLocator.GetService<MainCameraBrain>().SetLerp(lerp);
            GlobalServiceLocator.GetService<MainCameraBrain>().ChangeOrthographicSize(CameraSizeHelper.Slingshot);

            Time.timeScale = timeScale;
            FindObjectOfType<Cursor>().SetCursorIcon(cursor);
            FindObjectOfType<SlingshotShoot>().ActivateSlingshot();
        }
    }
}