using UnityEngine;

namespace AutumnForest
{
    public class GameManager : MonoBehaviour
    {
        //variables
        static private PlayerController player;
        static private Camera mainCamera;
        //getters
        static public PlayerController Player => player;
        static public Camera MainCamera => mainCamera;
        
        private void Awake()
        {
            player = FindObjectOfType<PlayerController>();    
            mainCamera = Camera.main;    
        }
    }
}