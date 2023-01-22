using UnityEngine;

namespace AutumnForest.BossFight.Slingshot
{
    public class SlingshotAudioEffect : MonoBehaviour
    {
        [SerializeField] private AudioSource shotAudioEffect;
        private Slingshot slingshot;

        //может это все таки лучше было бы интегрировать в сам скрипт рогатки /:

        private void Awake() => slingshot = GetComponent<Slingshot>();
        private void OnEnable() => slingshot.OnShoot += shotAudioEffect.Play;
        private void OnDisable() => slingshot.OnShoot -= shotAudioEffect.Play;
    }
}