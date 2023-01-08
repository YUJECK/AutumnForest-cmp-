using AutumnForest.Other;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest
{
    public sealed class Interactor : MonoBehaviour
    {
        private List<IInteractive> awailableInteractions = new();

        private void OnEnable() => GlobalServiceLocator.GetService<PlayerInput>().Player.Interact.performed += Interact;
        private void OnDisable() => GlobalServiceLocator.GetService<PlayerInput>().Player.Interact.performed -= Interact;

        private void Interact(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            for (int i = 0; i < awailableInteractions.Count; i++)
                awailableInteractions[i].Interact();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IInteractive interactive))
                awailableInteractions.Add(interactive);
        }
    }
}