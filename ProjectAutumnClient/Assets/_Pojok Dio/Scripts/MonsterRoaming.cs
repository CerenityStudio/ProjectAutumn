using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CerenityStudio
{
    public class MonsterRoaming : MonoBehaviour
    { 
        [Header("Facing Boolean")]
        [SerializeField] private bool isRight;
        
        [Header("Timer Value")]
        [SerializeField] private float initiateTimer;
        private float curentTimer;
        
        [Header("Rotation Value")]
        [SerializeField] private float rotationSpeed;

        private void Start()
        {
            curentTimer = initiateTimer;
        }

        void Update()
        {
            Roaming();
        }

        
        #region Private Method
        private void Roaming()
        {
            curentTimer -= Time.deltaTime;

            if (curentTimer <= 0 && isRight)
            {
                ResetTimer(false);
            }
            else if (curentTimer <= 0 && !isRight)
            {
                ResetTimer(true);
            }

            if (isRight)
                RotateEnemyHead(rotationSpeed);
            else
                RotateEnemyHead(-rotationSpeed);
        }

        private void RotateEnemyHead(float rotation)
        {
            transform.Rotate(0, 0, rotation * Time.deltaTime);
        }

        private void ResetTimer(bool condition)
        {
            isRight = condition;
            curentTimer = initiateTimer * 2;
        }
        
        #endregion
    }
}
