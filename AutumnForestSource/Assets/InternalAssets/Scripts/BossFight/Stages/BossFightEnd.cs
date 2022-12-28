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

        private void Start() => ServiceLocator.GetService<RaccoonStateMachine>().GetComponent<Health>().OnDie.AddListener(EndBossFight);
        private async void EndBossFight()
        {
            ServiceLocator.GetService<MainCameraBrain>().ChangeOrthographicSize(3f);
            ServiceLocator.GetService<MainCameraBrain>().SetTargets(ServiceLocator.GetService<PlayerController>().gameObject);
            Vignette vignette = ServiceLocator.GetService<MainCameraBrain>().GetPostProcessProfile().GetSetting<Vignette>();

            Color startColor = vignette.color.value;

            for (float i = 0.05f; vignette.color != newVignetteColor; i += 0.001f)
            {
                vignette.color.value = Color.Lerp(startColor, newVignetteColor, i);
                await Task.Delay(10);
            }
        }
    }
}