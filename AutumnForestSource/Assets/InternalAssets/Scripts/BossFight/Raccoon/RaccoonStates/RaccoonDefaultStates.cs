using AutumnForest.StateMachineSystem;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon.States
{
    public class RaccoonDefaultStates : MonoBehaviour, IStateVariation
    {
        public object InitStates()
        {
            return new RaccoonStateContainer(new RaccoonIdleState(),
                                      new RaccoonIdleState(),
                                      new RaccoonIdleState(),
                                      new RaccoonIdleState(),
                                      new RaccoonIdleState(),
                                      new RaccoonIdleState(),
                                      new RaccoonIdleState());
        }
    }
}