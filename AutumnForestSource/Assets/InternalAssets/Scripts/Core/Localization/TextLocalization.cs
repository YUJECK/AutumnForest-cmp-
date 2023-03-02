using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.Assets.InternalAssets.Scripts
{
    [RequireComponent(typeof(Text))]
    public sealed class TextLocalization : MonoBehaviour
    {
        [SerializeField] private Text uiText;

        [SerializeField] private LocalizatedString text = new();
        private void OnValidate()
        {
            if (uiText == null) uiText = GetComponent<Text>();
            UpdateText();
        }

        private void UpdateText()
        {
            uiText.text = text.Value;
        }


        //я изначально работал с ивентом для смены языка, но словил очень странный баг,
        //который мне было лень фикисть, поэтому просто впихнул обновления текста в апдейт
        private void Update()
        {
            UpdateText();
        }
    }
}