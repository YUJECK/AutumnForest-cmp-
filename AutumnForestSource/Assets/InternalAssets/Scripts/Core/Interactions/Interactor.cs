﻿using AutumnForest.Other;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest
{
    public sealed class Interactor : MonoBehaviour
    {
        [SerializeField] private GameObject vizualization;

        private List<IInteractive> awailableInteractions = new();

        private void OnEnable() => GlobalServiceLocator.GetService<PlayerInput>().Inputs.Interact.performed += Interact;
        private void OnDisable()
        {
            if (GlobalServiceLocator.TryGetService(out PlayerInput playerInput))
                playerInput.Inputs.Interact.performed -= Interact;
        }

        private void Interact(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            for (int i = 0; i < awailableInteractions.Count; i++)
                awailableInteractions[i].Interact();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IInteractive interactive))
            {
                interactive.Detect();
                awailableInteractions.Add(interactive);

                vizualization.SetActive(true);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IInteractive interactive))
            {
                if (awailableInteractions.Contains(interactive))
                {
                    interactive.DetectionReleased();
                    awailableInteractions.Remove(interactive);

                    if (awailableInteractions.Count == 0)
                        vizualization.SetActive(false);
                }
            }
        }
    }
}