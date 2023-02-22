using System;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.Catscenes
{
    public abstract class Catscene : MonoBehaviour
    {
        public UnityEvent OnCatsceneStarted = new();
        public UnityEvent OnCatsceneEnded = new();

        public void StartCatscene() 
        {
            OnCatsceneStart();
            OnCatsceneStarted.Invoke();
        }
        public void EndCutScene()
        {
            OnCatsceneEnd();
            OnCatsceneEnded.Invoke();
        }

        protected abstract void OnCatsceneStart();
        protected abstract void OnCatsceneEnd();
    }
}