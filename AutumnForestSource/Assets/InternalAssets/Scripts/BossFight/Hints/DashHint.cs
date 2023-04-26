using AutumnForest.Player;
using System;
using UnityEngine;

namespace AutumnForest
{
    [RequireComponent(typeof(Animator))]
    public sealed class DashHint : MonoBehaviour, IDisablable
    {
        [SerializeField] private GameObject hintPanel;

        private Animator animator;

        public bool Enabled { get; private set; }

        public event Action OnEnabled;
        public event Action OnDisabled;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            GlobalServiceLocator.GetService<PlayerDash>().OnDashStarted += Disable;
        }

        public void Disable()
        {
            GlobalServiceLocator.GetService<PlayerDash>().OnDashStarted -= Disable;
            animator.Play("DashHintDisable");
        }

        public void Enable()
        {
            animator.Play("DashHintEnable");
            EnablePanel();
        }

        private void DisablePanel() => hintPanel.SetActive(false);
        private void EnablePanel() => hintPanel.SetActive(true);
    }
}