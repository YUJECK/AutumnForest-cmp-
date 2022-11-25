using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUtilities : MonoBehaviour
{
    public void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    public void DestroyOther(GameObject obj) => Destroy(obj);  
    public void TransitionToScene(int scene) => SceneManager.LoadScene(scene); 
    public void Quit() => Application.Quit(); 
    public void OpenLink(string url) => Application.OpenURL(url); 
}