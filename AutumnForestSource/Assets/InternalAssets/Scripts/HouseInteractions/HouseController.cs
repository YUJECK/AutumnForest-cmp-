using AutumnForest.Managers;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AutumnForest
{
    public class HouseController : MonoBehaviour
    {
        [SerializeField] private Transform enterPoint;
        [SerializeField] private Transform exitPoint;

        public async UniTask EnterHouse()
        {
            await GlobalServiceLocator.GetService<BlackoutTransition>().StartBlackout();

            GlobalServiceLocator.GetService<PlayerMovable>().transform.position = enterPoint.position;
            GlobalServiceLocator.GetService<CameraSwitcher>().SwitchToHouseCamera();
        }
        public async UniTask ExitFromHouse()
        {
            await GlobalServiceLocator.GetService<BlackoutTransition>().StartBlackout();

            GlobalServiceLocator.GetService<PlayerMovable>().transform.position = exitPoint.position;
            GlobalServiceLocator.GetService<CameraSwitcher>().SwichToMainCamera();
        }
    }
}