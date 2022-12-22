using AutumnForest.BossFight;
using UnityEngine;

namespace AutumnForest.Other
{
    public class SligshootKeyDown : OnKeyDownEvent
    {

        [SerializeField] SlingshotShoot slingshot;

        protected override void OnKeyPressed()
        {


            slingshot.Active();
        }
    }
}