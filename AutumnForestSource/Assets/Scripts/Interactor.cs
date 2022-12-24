using AutumnForest.Other;
using AutumnForest.Player;
using UnityEngine;

namespace AutumnForest
{
    public class Interactor : MonoBehaviour
    {
        //fields
        private Transform interactionPoint;
        private float interactionRange = 0.5f;
        private LayerMask interactableMask;

        //unity methods
        private void Awake() => ServiceLocator.GetService<PlayerInput>().AddInput(KeyCode.E, Interact, true);

        //methods
        private void Interact()
        {
            Collider2D[] hittedColliders = Physics2D.OverlapCircleAll(interactionPoint.position, interactionRange, interactableMask);

            foreach (Collider2D collider in hittedColliders)
            {
                if (collider.gameObject.TryGetComponent(out IInteractive interactible))
                    interactible.Interact();
            }
        }
    }
}