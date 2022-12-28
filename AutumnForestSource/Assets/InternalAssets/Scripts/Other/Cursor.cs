using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Cursor : MonoBehaviour
{
    //fields
    private Camera mainCamera;
    private Image UIIcon;

    //unity methods
    void Awake()
    {
        mainCamera = Camera.main;
        UIIcon = GetComponent<Image>();
    }
    void Update()
    {
        transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
    //methods
    public void SetCursorIcon(Sprite newIcon) => UIIcon.sprite = newIcon;
}