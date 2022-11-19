using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [TextArea(2,10)]
    [SerializeField] private List<string> phrases = new List<string>();
    [SerializeField] private Text UIText;
    private int currentPhrase = 0;
    public UnityEvent onConversationStarts = new UnityEvent();
    public UnityEvent onConversationEnds = new UnityEvent();

    public void RepeatConversationAgain() => currentPhrase = 0;
    public void NextPhrase()
    {
        if (currentPhrase == 0)
            onConversationStarts.Invoke();
        if (currentPhrase >= phrases.Count)
            onConversationEnds.Invoke();
        else
        {
            UIText.text = phrases[currentPhrase];
            currentPhrase++;
        }
    }
}