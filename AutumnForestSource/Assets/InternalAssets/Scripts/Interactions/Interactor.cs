using AutumnForest.Other;   
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest
{
    public sealed class Interactor : MonoBehaviour
    {
        private List<IInteractive> awailableInteractions = new();

        private void OnEnable() => GlobalServiceLocator.GetService<PlayerInput>().Inputs.Interact.performed += Interact;
        private void OnDisable() => GlobalServiceLocator.GetService<PlayerInput>().Inputs.Interact.performed -= Interact;

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
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IInteractive interactive))
            {
                if (awailableInteractions.Contains(interactive))
                    awailableInteractions.Remove(interactive);
            }
        }
    }
}