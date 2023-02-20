using UnityEngine.SceneManagement;

namespace AutumnForest
{
    public static class SceneReload
    {
        public static async void RestartScene()
        {
            await GlobalServiceLocator.GetService<BlackoutTransition>().StartBlackout();
            
            GlobalServiceLocator.UnregisterAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}