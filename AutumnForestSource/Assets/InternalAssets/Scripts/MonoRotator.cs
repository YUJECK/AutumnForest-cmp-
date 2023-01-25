using UnityEngine;

namespace AutumnForest.Other
{
    public sealed class MonoRotator : MonoBehaviour
    {
        [SerializeField] private TransformRotation.RotateType rotateType;
        [SerializeField] private float coefficent = 1;
        [SerializeField] private Transform target;

        public TransformRotation.RotateType RotateType => rotateType;

        public TransformRotation TransfromRotation { get; private set; }

        private void Awake()
        {
            TransfromRotation = new(transform, target, 1, rotateType);
        }
        private void OnValidate()
        {
            if(TransfromRotation != null)
            {
                TransfromRotation.Coefficient = coefficent;
                TransfromRotation.RotationType= rotateType;
            }
        }
    }
}