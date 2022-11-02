using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialoge : MonoBehaviour
{
    [TextArea(2,10)]
    [SerializeField] private List<string> dialoges = new List<string>();
    [SerializeField] private Text UIText;
    private int currentDialogue = 0;

    public void NextConversation()
    {
        currentDialogue++;
        if (currentDialogue >= dialoges.Count) currentDialogue = 0;

        UIText.text = dialoges[currentDialogue];
    }
}