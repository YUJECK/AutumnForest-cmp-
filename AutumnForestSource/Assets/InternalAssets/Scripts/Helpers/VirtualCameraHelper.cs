using Cinemachine;

namespace AutumnForest.Helpers
{
    public sealed class VirtualCameraHelper
    {
        public CinemachineVirtualCamera MainCamera { get; private set; }
        public CinemachineVirtualCamera BossfightCamera { get; private set; }
        public CinemachineVirtualCamera SlingshotCamera { get; private set; }

        public VirtualCameraHelper(CinemachineVirtualCamera mainCamera, CinemachineVirtualCamera bossfightCamera, CinemachineVirtualCamera slingshotCamera)
        {
            this.MainCamera = mainCamera;
            this.BossfightCamera = bossfightCamera;
            this.SlingshotCamera = slingshotCamera;
        }
    }
}