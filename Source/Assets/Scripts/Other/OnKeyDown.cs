using UnityEngine;
using UnityEngine.Events;

public class OnKeyDown : MonoBehaviour
{
    public bool isActive;
    [SerializeField] private KeyCode keyCode = KeyCode.E;
    public UnityEvent onKeyDown = new UnityEvent();

    public void SetActive(bool active) => isActive = active;
    private void Update()
    {
        if (isActive && Input.GetKeyDown(keyCode))
            onKeyDown.Invoke();
    }
}