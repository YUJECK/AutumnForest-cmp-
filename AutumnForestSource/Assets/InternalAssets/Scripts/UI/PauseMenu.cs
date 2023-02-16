using UnityEngine;

namespace AutumnForest
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        private bool paused = false;

        private void Awake() => Continue();

        private void OnEnable() => GlobalServiceLocator.GetService<PlayerInput>().Inputs.PauseMenu.performed += PauseMenuInput;
        private void OnDisable()
        {
            if (GlobalServiceLocator.TryGetService(out PlayerInput playerInput))
                playerInput.Inputs.PauseMenu.performed -= PauseMenuInput;
        }

        private void PauseMenuInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (paused) Continue();    
            else Pause();    
        }

        public void Pause()
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        
            paused = true;
        }
        public void Continue()
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            
            paused = false;
        }
    }
}