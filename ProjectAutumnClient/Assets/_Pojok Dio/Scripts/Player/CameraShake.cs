using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CerenityStudio
{
    public class CameraShake : MonoBehaviour
    {
        Vector3 cameraInitialPosition;
        public float shakeMagnetude = 0.05f, shakeTime = 0.5f;
        public Camera mainCamera;
        [SerializeField] private GameObject virtualCamera;

        public void ShakeCamera()
        {
            virtualCamera.SetActive(false);
            cameraInitialPosition = mainCamera.transform.position;
            InvokeRepeating ("StartCameraShaking", 0f, 0.005f);
            Invoke ("StopCameraShaking", shakeTime);
        }

        void StartCameraShaking()
        {
            float cameraShakingOffsetX = Random.value * shakeMagnetude * 2 - shakeMagnetude;
            float cameraShakingOffsetY = Random.value * shakeMagnetude * 2 - shakeMagnetude;
            Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
            cameraIntermadiatePosition.x += cameraShakingOffsetX;
            cameraIntermadiatePosition.y += cameraShakingOffsetY;
            mainCamera.transform.position = cameraIntermadiatePosition;
        }

        void StopCameraShaking()
        {
            CancelInvoke ("StartCameraShaking");
            mainCamera.transform.position = cameraInitialPosition;
        }
    }
}


