using AutumnForest.EditorScripts;
using AutumnForest.Health;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(IHealth))]
    public class HealthChangeColorEffect : MonoBehaviour
    {
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color healColor;
        [SerializeField] private Color damageColor;

        private SpriteRenderer spriteRenderer;
        [SerializeField, Interface(typeof(IHealth))] private UnityEngine.Object healthObject;
        private IHealth health;



        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            health = (IHealth)healthObject;
        }
        private void OnEnable()
        {
            health.OnTakeHit += OnTakeHit;
            health.OnHealed += OnHeal;
        }  
        private void OnDisable()
        {
            health.OnTakeHit -= OnTakeHit;
            health.OnHealed -= OnHeal;
        }

        private async void OnHeal(int arg1, int arg2)
        {
            spriteRenderer.color = healColor;
            await UniTask.Delay(TimeSpan.FromSeconds(0.3f));
            spriteRenderer.color = defaultColor;
        }

        private async void OnTakeHit(int arg1, int arg2)
        {
            spriteRenderer.color = damageColor;
            await UniTask.Delay(TimeSpan.FromSeconds(0.3f));
            spriteRenderer.color = defaultColor;
        }
    }
}