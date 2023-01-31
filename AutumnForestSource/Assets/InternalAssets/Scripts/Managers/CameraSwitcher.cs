using Cinemachine;
using System;
using UnityEngine;

namespace AutumnForest.Managers
{
    public sealed class CameraSwitcher
    {
        private GameObject mainCamera;
        private GameObject bossfightCamera;
        private GameObject slingshotCamera;
        private CinemachineVirtualCamera dialogueCamera;
        private GameObject houseCamera;
        private GameObject basementCamera;

        private GameObject currentCamera;
        private GameObject previousCamera;
        
        public CameraSwitcher(CinemachineVirtualCamera mainCamera, CinemachineVirtualCamera bossfightCamera, 
            CinemachineVirtualCamera slingshotCamera, CinemachineVirtualCamera dialogueCamera, CinemachineVirtualCamera houseCamera, CinemachineVirtualCamera basementCamera)
        {
            this.mainCamera = mainCamera.gameObject;
            this.bossfightCamera = bossfightCamera.gameObject;
            this.slingshotCamera = slingshotCamera.gameObject;
            this.dialogueCamera = dialogueCamera;
            this.houseCamera = houseCamera.gameObject;
            this.basementCamera = basementCamera.gameObject;

            this.mainCamera.SetActive(false);
            this.bossfightCamera.SetActive(false);
            this.slingshotCamera.SetActive(false);    
            dialogueCamera.gameObject.SetActive(false);
            this.houseCamera.SetActive(false);
            this.basementCamera.SetActive(false);

            SwichToMainCamera();
        }

        public void SwichToMainCamera() => Switch(mainCamera);
        public void SwitchToBossFightCamera() => Switch(bossfightCamera);
        public void SwitchToSlingshotCamera() => Switch(slingshotCamera);
        public void SwitchToHouseCamera() => Switch(houseCamera);
        public void SwitchToBasementCamera() => Switch(basementCamera);
        public void SwitchToDialogueCamera(Transform target)
        {
            if (target == null)
                throw new NullReferenceException(nameof(target));

            dialogueCamera.Follow = target;
            Switch(dialogueCamera.gameObject);
        }
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