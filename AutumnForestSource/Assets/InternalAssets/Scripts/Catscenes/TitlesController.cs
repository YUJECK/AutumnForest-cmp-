using AutumnForest.Catscenes;
using UnityEngine;

namespace AutumnForest.Titles
{
    public class TitlesController : MonoBehaviour
    {
        [SerializeField] private Catscene[] catscenes;
        private int currentCutscene;

        private void Start() => StartPlayCatscenes();

        private void StartPlayCatscenes()
        {
            catscenes[currentCutscene].OnCatsceneEnded.AddListener(Switch);
            catscenes[currentCutscene].StartCatscene();
        }
        private void Switch()
        {
            catscenes[currentCutscene].OnCatsceneEnded.RemoveListener(Switch);
            {
                currentCutscene++;
                if (currentCutscene >= catscenes.Length) return;

                catscenes[currentCutscene].StartCatscene();
            }
            catscenes[currentCutscene].OnCatsceneEnded.AddListener(Switch);
        }
    }
}