using UnityEngine;
using UnityEngine.Events;

public class OnKeyDownEvent : MonoBehaviour
{
    public bool isActive;
    [SerializeField] private KeyCode keyCode = KeyCode.E;
    public UnityEvent OnKeyDown = new UnityEvent();

    public void SetActive(bool active) => isActive = active;
    protected virtual void OnKeyPressed() { }
    private void Update()
    {
        if (isActive && Input.GetKeyDown(keyCode))
        {
            OnKeyDown.Invoke();
            OnKeyPressed();
        }
    }
}