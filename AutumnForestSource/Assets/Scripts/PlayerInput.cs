using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private bool isActive = true;
        //inputs
        private Vector2 movement;
        public UnityEvent OnLeftMouseButtonPressed = new();
        public UnityEvent OnRightMouseButtonPressed = new();
        public UnityEvent OnMiddleMouseButtonPressed = new();
        private readonly Dictionary<KeyCode, UnityAction> playerInputs = new();

        //getters
        public Vector2 Movement => movement;
        //unity methods
        private void Update()
        {
            //player movement
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            //mouse input
            if (Input.GetMouseButtonDown(0)) OnLeftMouseButtonPressed.Invoke();
            if (Input.GetMouseButtonDown(1)) OnRightMouseButtonPressed.Invoke();
            if (Input.GetMouseButtonDown(2)) OnMiddleMouseButtonPressed.Invoke();

            //keyboard input
            if (isActive)
            {
                foreach (KeyCode key in playerInputs.Keys)
                {
                    if (Input.GetKeyDown(key))
                        playerInputs[key]?.Invoke();
                }
            }
        }
        //methods
        public void AddInput(KeyCode key, UnityAction action, bool replace)
        {
            if (!playerInputs.ContainsKey(key) || !replace) playerInputs.Add(key, action);
            else playerInputs[key] = action;
        }
        public void RemoveInput(KeyCode key)
        {
            if (playerInputs.ContainsKey(key))  playerInputs.Remove(key);
            else Debug.LogError($"PlayerInputs doesnt contain {key}");
        }
    }
}