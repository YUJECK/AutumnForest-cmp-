using UnityEngine;
using UnityEngine.Events;

public class BossFightController : MonoBehaviour
{
    public void StartBossFight() => onBossFightBegins.Invoke();
    public void EndBossFight() => onBossFightEnds.Invoke();

    public UnityEvent onBossFightBegins = new UnityEvent();
    public UnityEvent onBossFightEnds = new UnityEvent();
}