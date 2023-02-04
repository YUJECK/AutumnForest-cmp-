using UnityEngine;

namespace AutumnForest
{
    public sealed class MusicSwitcher
    {
        private AudioSource mainTheme;
        private AudioSource bossfightTheme;
        private AudioSource basementAmbientTheme;
        private AudioSource gramophoneTheme;

        private AudioSource currentTheme;
        private AudioSource previousTheme;

        public MusicSwitcher(AudioSource mainTheme, AudioSource bossfightTheme, AudioSource basementAmbientTheme, AudioSource gramophoneTheme)
        {
            this.mainTheme = mainTheme;
            this.bossfightTheme = bossfightTheme;
            this.basementAmbientTheme = basementAmbientTheme;
            this.gramophoneTheme = gramophoneTheme;

            this.mainTheme.Stop();
            this.bossfightTheme.Stop();
            this.basementAmbientTheme.Stop();
            this.gramophoneTheme.Stop();

            SwitchToMainTheme();
        }

        public void SwitchToMainTheme() => Switch(mainTheme);
        public void SwitchToBossFightTheme() => Switch(bossfightTheme);
        public void SwitchToBasementAmbient() => Switch(basementAmbientTheme);
        public void SwitchToGramophone() => Switch(gramophoneTheme);
        public void SwitchToPrevious() => Switch(previousTheme);

        private void Switch(AudioSource theme)
        {
            previousTheme = currentTheme;
            previousTheme?.Stop();

            currentTheme = theme;
            currentTheme.Play();
        }
    }
}