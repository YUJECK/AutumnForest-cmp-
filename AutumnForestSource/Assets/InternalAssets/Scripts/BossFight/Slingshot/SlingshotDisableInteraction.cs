using AutumnForest.Helpers;
using AutumnForest.Other;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.BossFight
{
    class SlingshotDisableInteraction : MonoBehaviour, IInteractive
    {
        [SerializeField] private float lerp = 0.15f;
        [SerializeField] private float timeScale = 1f;
        [SerializeField] private Sprite cursor;

        public UnityEvent OnInteract { get; set; } = new();

        event Action IInteractive.OnInteract
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void Interact()
        {
            GlobalServiceLocator.GetService<MainCameraBrain>().SetLerp(lerp);
            GlobalServiceLocator.GetService<MainCameraBrain>().ChangeOrthographicSize(CameraSizeHelper.BossFight);

            Time.timeScale = timeScale;
            FindObjectOfType<Cursor>().SetCursorIcon(cursor);
            FindObjectOfType<SlingshotShoot>().DisableSlingshot();
        }
    }
}