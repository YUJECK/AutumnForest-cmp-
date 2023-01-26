using Cinemachine;
using UnityEngine;

namespace AutumnForest.Managers
{
    public sealed class CameraSwitcher
    {
        private GameObject mainCamera;
        private GameObject bossfightCamera;
        private GameObject slingshotCamera;

        private GameObject currentCamera;
        private GameObject previousCamera;

        public CameraSwitcher(CinemachineVirtualCamera mainCamera, CinemachineVirtualCamera bossfightCamera, CinemachineVirtualCamera slingshotCamera)
        {
            this.mainCamera = mainCamera.gameObject;
            this.bossfightCamera = bossfightCamera.gameObject;
            this.slingshotCamera = slingshotCamera.gameObject;

            mainCamera.gameObject.SetActive(false);
            slingshotCamera.gameObject.SetActive(false);
            bossfightCamera.gameObject.SetActive(false);

            SwichToMainCamera();
        }

        public void SwichToMainCamera() => Switch(mainCamera);
        public void SwitchToBossFightCamera() => Switch(bossfightCamera);
        public void SwitchToSlingshotCamera() => Switch(slingshotCamera);
        public void SwitchToPrevious() => Switch(previousCamera);
    
        private void Switch(GameObject camera)
        {
            previousCamera = currentCamera;
            previousCamera?.SetActive(false);

            currentCamera = camera;
            currentCamera.SetActive(true);
        }
    }
}