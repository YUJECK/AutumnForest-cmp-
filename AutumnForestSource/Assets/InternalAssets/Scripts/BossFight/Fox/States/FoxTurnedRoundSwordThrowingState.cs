using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;

namespace AutumnForest.BossFight.Fox.States
{
    public sealed class FoxSingleSwordCastState : StateBehaviour
    {
        private float swordForce = 15;

        public FoxSingleSwordCastState(float swordForce)
        {
            this.swordForce = swordForce;
        }

        public override void EnterState(IStateMachineUser stateMachine)
        {
            IsCompleted = false;
            {
                stateMachine.ServiceLocator.GetService<Shooting>().ShootWithoutInstantiate(
                    GlobalServiceLocator.GetService<SomePoolsContainer>().DefaultSwordPool.GetFree().Rigidbody2D,
                    swordForce,
                    0f,
                    true);
            }
            IsCompleted = true;
        }
    }
}