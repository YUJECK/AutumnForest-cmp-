using UnityEngine;
using UnityEngine.SceneManagement;

namespace AutumnForest
{
    public sealed class ButtonMethods : MonoBehaviour
    {
        public void ChangeLanguage(int index)
        {
            if (index == 0) LanguageManager.Switch(Language.English);
            if (index == 1) LanguageManager.Switch(Language.Russian);
        }
        public void SwitchScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
            GlobalServiceLocator.UnregisterAll();
        }
        public void Exit() => Application.Quit();
        public void Enable(GameObject gameObject) => gameObject.SetActive(true);
        public void EnableDisable(GameObject gameObject) => gameObject.SetActive(!gameObject.activeSelf);
        public void Disable(GameObject gameObject) => gameObject.SetActive(false);
    }
}