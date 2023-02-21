using System;
using UnityEngine;

namespace AutumnForest.Cutscenes
{
    public abstract class Catscene : MonoBehaviour
    {
        public event Action OnCatsceneStarted;
        public event Action OnCatsceneEnded;

        public void StartCatscene() 
        {
            OnCatsceneStart();
            OnCatsceneStarted?.Invoke();
        }
        public void EndCutScene()
        {
            OnCatsceneEnd();
            OnCatsceneEnded?.Invoke();
        }

        protected abstract void OnCatsceneStart();
        protected abstract void OnCatsceneEnd();
    }
}