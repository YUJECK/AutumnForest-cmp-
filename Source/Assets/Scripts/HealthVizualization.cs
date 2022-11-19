using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthVizualization : MonoBehaviour
{
    [SerializeField] private Text text;

    private void Start() => GetComponent<Health>().onHealthChange.AddListener(ChangeBar);

    private void ChangeBar(int cur, int max)
    {
        text.text = cur + "/" + max;
    }
}