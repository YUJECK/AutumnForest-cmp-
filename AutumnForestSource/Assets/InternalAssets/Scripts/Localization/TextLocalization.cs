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
            text = GetComponent<Text>();

            text.text = englishText;

            LanguageManager.OnLanguageChanged += OnLanguageChanged;
        }

        private void OnValidate()
        {
        }
        private void OnLanguageChanged(Language language)
        {
            if (language == Language.English) text.text = englishText;
            else if (language == Language.Russian) text.text = russianText;
        }
    }
}