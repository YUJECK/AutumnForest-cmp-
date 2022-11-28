using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(OnKeyDownEvent))]
public class Dialogue : MonoBehaviour
{
    //variables
    [TextArea(2, 10)]
    [SerializeField] private string name = "Somebody";
    [SerializeField] private List<string> phrases = new List<string>();
    private int currentPhrase = 0;
    //events
    public UnityEvent<Dialogue> OnConversationStarts = new UnityEvent<Dialogue>();
    public UnityEvent<string, string> OnNextPhrase = new UnityEvent<string, string>();
    public UnityEvent OnConversationEnds = new UnityEvent();

    //methods
    public void StartConversation()
    {
        currentPhrase = 0;
        OnConversationStarts.Invoke(this);
        NextPhrase();
    }
    public void EndConversation() => OnConversationEnds.Invoke();
    public void NextPhrase()
    {
        if (currentPhrase >= phrases.Count)
            OnConversationEnds.Invoke();
        else
        {
            OnNextPhrase.Invoke(phrases[currentPhrase], name);
            currentPhrase++;
        }
    }

    //unity methods
    private void Start() => GetComponent<OnKeyDownEvent>().onKeyDown.AddListener(NextPhrase);
}