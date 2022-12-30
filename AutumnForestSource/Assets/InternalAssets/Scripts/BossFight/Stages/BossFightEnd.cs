using AutumnForest.BossFight.Raccoon;
using AutumnForest.Other;
using AutumnForest.Player;
using CreaturesAI.Health;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace AutumnForest.BossFight
{
    public class BossFightEnd : MonoBehaviour
    {
        [SerializeField] private Color newVignetteColor;

        private void Start() => GlobalServiceLocator.GetService<RaccoonStateMachine>().GetComponent<Health>().OnDie.AddListener(EndBossFight);
        private async void EndBossFight()
        {
            GlobalServiceLocator.GetService<MainCameraBrain>().ChangeOrthographicSize(3f);
            GlobalServiceLocator.GetService<MainCameraBrain>().SetTargets(GlobalServiceLocator.GetService<PlayerMovable>().gameObject);
            Vignette vignette = GlobalServiceLocator.GetService<MainCameraBrain>().GetPostProcessProfile().GetSetting<Vignette>();

            Color startColor = vignette.color.value;

            for (float i = 0.05f; vignette.color != newVignetteColor; i += 0.001f)
            {
                vignette.color.value = Color.Lerp(startColor, newVignetteColor, i);
                await Task.Delay(10);
            }
        }
    }
}