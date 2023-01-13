using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

[RequireComponent(typeof(SpriteRenderer))]
public class Cursor : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer cursorIcon;

    void Awake()
    {
        mainCamera = Camera.main;
        cursorIcon = GetComponent<SpriteRenderer>();
    }
    void LateUpdate()
    {
        Vector3 newPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPos.x, newPos.y, -100f);
    }
    //methods
    public void SetCursorIcon(Sprite newIcon) => cursorIcon.sprite = newIcon;
}