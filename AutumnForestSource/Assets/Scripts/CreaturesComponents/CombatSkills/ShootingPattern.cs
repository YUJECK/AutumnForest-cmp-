using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class ShootingPattern : ScriptableObject
{
    public UnityEvent OnPatternEnd = new UnityEvent();
    protected bool isFinished = false;
    private Coroutine patternCoroutine;

    public bool IsFinished => isFinished;

    public void UsePattern(Shooting shooting) => patternCoroutine = shooting.StartCoroutine(Pattern(shooting));
    public void CompletePattern(Shooting shooting)
    {
        if(patternCoroutine != null) 
            shooting.StopCoroutine(patternCoroutine);
    }
    public abstract IEnumerator Pattern(Shooting shooting);
}