using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void RestartScene() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
    public void TransitionToEnd() { SceneManager.LoadScene(1); }
    public void Quit() { Application.Quit(); }
    public void OpenLink(string url) { Application.OpenURL(url); }
}