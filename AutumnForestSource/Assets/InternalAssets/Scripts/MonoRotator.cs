using UnityEngine;

namespace AutumnForest.Other
{
    public sealed class MonoRotator : MonoBehaviour
    {
        [SerializeField] private TransformRotation.RotateType rotateType;
        [SerializeField] private Transform target;
        [SerializeField] private bool asPlayer;
        
        [SerializeField] private float coefficent = 1;

        public TransformRotation.RotateType RotateType => rotateType;
        public TransformRotation TransfromRotation { get; private set; }


        private void Awake()
        {
            if (asPlayer)
                target = GameObject.FindGameObjectWithTag(TagHelper.PlayerTag).transform;

            TransfromRotation = new(transform, target, coefficent, rotateType);
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