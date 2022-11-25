using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [TextArea(2, 10)]
    [SerializeField] private List<string> phrases = new List<string>();
    [SerializeField] private Text UIText;
    private int currentPhrase = 0;
    public UnityEvent onConversationStarts = new UnityEvent();
    public UnityEvent onConversationEnds = new UnityEvent();

    public void StartConversation()
    {
        currentPhrase = 0;
        NextPhrase();
        onConversationStarts.Invoke();
    }
    public void NextPhrase()
    {
        if (currentPhrase >= phrases.Count)
        {
            onConversationEnds.Invoke();
            Debug.Log("Conversation ends");
        }
        else
        {
            UIText.text = phrases[currentPhrase];
            currentPhrase++;
        }
    }
}