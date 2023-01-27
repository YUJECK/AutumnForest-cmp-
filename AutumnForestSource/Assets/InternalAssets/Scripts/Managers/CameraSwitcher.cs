using Cinemachine;
using UnityEngine;

namespace AutumnForest.Managers
{
    public sealed class CameraSwitcher
    {
        private GameObject mainCamera;
        private GameObject bossfightCamera;
        private GameObject slingshotCamera;
        private GameObject houseCamera;
        private GameObject basementCamera;

        private GameObject currentCamera;
        private GameObject previousCamera;
        
        public CameraSwitcher(CinemachineVirtualCamera mainCamera, CinemachineVirtualCamera bossfightCamera, 
            CinemachineVirtualCamera slingshotCamera, CinemachineVirtualCamera houseCamera, CinemachineVirtualCamera basementCamera)
        {
            this.mainCamera = mainCamera.gameObject;
            this.bossfightCamera = bossfightCamera.gameObject;
            this.slingshotCamera = slingshotCamera.gameObject;
            this.houseCamera = houseCamera.gameObject;
            this.basementCamera = basementCamera.gameObject;

            mainCamera.gameObject.SetActive(false);
            slingshotCamera.gameObject.SetActive(false);
            bossfightCamera.gameObject.SetActive(false);
            houseCamera.gameObject.SetActive(false);
            basementCamera.gameObject.SetActive(false);

            SwichToMainCamera();
        }

        public void SwichToMainCamera() => Switch(mainCamera);
        public void SwitchToBossFightCamera() => Switch(bossfightCamera);
        public void SwitchToSlingshotCamera() => Switch(slingshotCamera);
        public void SwitchToHouseCamera() => Switch(houseCamera);
        public void SwitchToBasementCamera() => Switch(basementCamera);
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