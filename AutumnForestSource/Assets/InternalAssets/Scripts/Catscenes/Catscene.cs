using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.Catscenes
{
    public abstract class Catscene : MonoBehaviour
    {
        public UnityEvent OnCatsceneStarted = new();
        public UnityEvent OnCatsceneEnded = new();

        [SerializeField] protected List<GameObject> objectsInCatscene = new();

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

        protected void SetCatsceneObjectsActive(bool active)
        {
            foreach (var item in objectsInCatscene)
                item?.SetActive(active);
        }
    }
}