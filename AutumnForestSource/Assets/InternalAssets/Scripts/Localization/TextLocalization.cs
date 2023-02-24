using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.Assets.InternalAssets.Scripts
{
    [RequireComponent(typeof(Text))]
    public sealed class TextLocalization : MonoBehaviour
    {
        private Text text;

        [SerializeField, TextArea(1, 5)] private string englishText;
        [SerializeField, TextArea(1, 5)] private string russianText;

        private void Awake()
        {
            if (text == null) text = GetComponent<Text>();
            LanguageManager.OnLanguageChanged += OnLanguageChanged;
        }

        private void OnValidate()
        {
            if(text == null) text = GetComponent<Text>();
            text.text = englishText;
        }
        private void OnLanguageChanged(Language language)
        {
            if (language == Language.English) text.text = englishText;
            else if (language == Language.Russian) text.text = russianText;
        }
    }
}