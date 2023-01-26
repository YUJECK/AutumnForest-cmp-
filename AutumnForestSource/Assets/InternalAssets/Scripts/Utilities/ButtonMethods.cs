using UnityEngine;
using UnityEngine.SceneManagement;

namespace AutumnForest
{
    public sealed class ButtonMethods : MonoBehaviour
    {
        public void SwitchScene(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
        public void Exit() => Application.Quit();

        //мб надо будет развить эту тему с uiWindow, но я еще сам не до конца понял, что от нее хочу
        public void OpenWindow(UIWindow window) => window.EnableWindow();
    }
}