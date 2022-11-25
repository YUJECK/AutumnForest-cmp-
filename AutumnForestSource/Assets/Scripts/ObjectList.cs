using CreaturesAI.Pathfinding;
using UnityEngine;

public sealed class ObjectList : MonoBehaviour
{
    //variables
    static private GridManager grid;
    static private PlayerController player;
    static private Camera mainCamera;
    static private GameObject mainTheme; //–имуру, не бей. я знаю что это кривое решение
    static private GameObject bossfightTheme;
    
    //getters
    static public GridManager Grid => grid;        
    static public PlayerController Player => player;
    static public Camera MainCamera => mainCamera;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        mainCamera = Camera.main;
        grid = FindObjectOfType<GridManager>();
        mainTheme = GameObject.Find("MainTheme");
        bossfightTheme = GameObject.Find("BossfightTheme");
    }
}