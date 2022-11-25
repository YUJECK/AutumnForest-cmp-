using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Camera mainCamera;
    
    void Start() => mainCamera = Camera.main;
    void Update()
    {
        transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
}