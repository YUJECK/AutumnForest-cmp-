using Cinemachine;
using UnityEngine;

namespace AutumnForest.Managers
{
    public sealed class CameraSwitcher
    {
        private GameObject mainCamera;
        private GameObject bossfightCamera;
        private GameObject slingshotCamera;

        public CameraSwitcher(CinemachineVirtualCamera mainCamera, CinemachineVirtualCamera bossfightCamera, CinemachineVirtualCamera slingshotCamera)
        {
            this.mainCamera = mainCamera.gameObject;
            this.bossfightCamera = bossfightCamera.gameObject;
            this.slingshotCamera = slingshotCamera.gameObject;
        }

        public void SwichToMainCamera()
        {
            if (slingshotCamera.gameObject.activeInHierarchy)
                slingshotCamera.gameObject.SetActive(false);
            if (bossfightCamera.gameObject.activeInHierarchy)
                bossfightCamera.gameObject.SetActive(false);

            mainCamera.SetActive(true);
        }
        public void SwitchToBossFightCamera()
        {
            if (slingshotCamera.gameObject.activeInHierarchy)
                slingshotCamera.gameObject.SetActive(false);
            if (mainCamera.gameObject.activeInHierarchy)
                mainCamera.gameObject.SetActive(false);

            bossfightCamera.SetActive(true);
        }
        public void SwitchToSlingshotCamera()
        {
            if (mainCamera.gameObject.activeInHierarchy)
                mainCamera.gameObject.SetActive(false);
            if (bossfightCamera.gameObject.activeInHierarchy)
                bossfightCamera.gameObject.SetActive(false);

            slingshotCamera.SetActive(true);
        }
    }
}