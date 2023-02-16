using System;
using UnityEngine;

namespace AutumnForest.BossFight
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AreaHit))]
    public sealed class Shirt : MonoBehaviour
    {
        [SerializeField] private int damage = 5;

        public event Action OnShirtLanded;
        private AreaHit areaHit;


        private void Awake()
        {
            areaHit = GetComponent<AreaHit>();

            OnShirtLanded += OnLanded;
        }

        private void OnLanded()
        {
            areaHit.Hit(damage);
            gameObject.SetActive(false);
        }

        public void Landed() => OnShirtLanded?.Invoke(); //for animator
    }
}