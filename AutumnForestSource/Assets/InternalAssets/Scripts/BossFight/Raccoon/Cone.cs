using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public sealed class Cone : MonoBehaviour, IFireable
    {
        public bool Fired => throw new System.NotImplementedException("иди имплементируй лодырь");

        public void Fire()
        {
            Debug.Log("Fired");
        }
    }
}