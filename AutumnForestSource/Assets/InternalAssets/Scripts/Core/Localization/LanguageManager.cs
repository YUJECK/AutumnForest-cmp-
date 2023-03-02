using System;
using UnityEngine;

namespace AutumnForest
{
    public enum Language
    {
        English,
        Russian
    }

    [Serializable]
    public class LocalizatedString
    {
        [SerializeField, TextArea(1, 20)] private string english;
        [SerializeField, TextArea(1, 20)] private string russian;

        public string Value
        {
            get
            {
                if (LanguageManager.Language == Language.English) return english;
                else return russian;
            }
            private set { }
        }
    }
    public static class LanguageManager
    {
        public static Language Language { get; private set; }
        public static event Action<Language> OnLanguageChanged;

        public static void Switch(Language newLanguage)
        {
            Language = newLanguage;

            OnLanguageChanged?.Invoke(newLanguage);
        }
    }
}