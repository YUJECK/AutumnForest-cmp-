using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public sealed class Cone : MonoBehaviour, IFireable
    {


        public void Fire()
        {
            Debug.Log("Fired");
        }
    }
}