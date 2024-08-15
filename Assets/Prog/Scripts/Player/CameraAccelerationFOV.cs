using System;
using Cinemachine;
using UnityEngine;

namespace Prog.Scripts.Player
{
    public class CameraAccelerationFOV : MonoBehaviour
    {
        private Rigidbody Rigidbody;
        [SerializeField] private CinemachineVirtualCamera targetCamera;
        [SerializeField] private float fovMin = 60;
        [SerializeField] private float fovBase = 75;
        [SerializeField] private float fovMax = 90;
        [SerializeField] private float accelerationSensitivity = 1;
        [SerializeField] private float DeltaFOV = 1;
        
        private float previousVelocity;
        
        private void Awake()
        {
            this.Rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            // Berechne die aktuelle Beschleunigung
            
            bool isVelocityRising = this.Rigidbody.velocity.z > this.previousVelocity;
            
            float currentVelocity = this.Rigidbody.velocity.z;
            float acceleration = (currentVelocity - this.previousVelocity) / Time.deltaTime;
            
            this.previousVelocity = currentVelocity;

            // Berechne den neuen FOV-Wert basierend auf der Beschleunigung
            float accelerationMagnitude = acceleration * this.accelerationSensitivity;

            float value = 0;
            float newFOV = 0;


            if (accelerationMagnitude > 1)
            {
                value = this.DeltaFOV;
                float IncrementedFOV = this.targetCamera.m_Lens.FieldOfView + value;
                newFOV = Mathf.Clamp(IncrementedFOV, this.fovMin, this.fovMax);
            }
            else if (accelerationMagnitude < -1)
            {
                value = -this.DeltaFOV;
                float IncrementedFOV = this.targetCamera.m_Lens.FieldOfView + value;
                newFOV = Mathf.Clamp(IncrementedFOV, this.fovMin, this.fovMax);
            }
            else
            {
                float IncrementedFOV = this.targetCamera.m_Lens.FieldOfView;

                if (this.targetCamera.m_Lens.FieldOfView > this.fovBase)
                {
                    value = -this.DeltaFOV;
                    IncrementedFOV = this.targetCamera.m_Lens.FieldOfView + value;
                    newFOV = Mathf.Clamp(IncrementedFOV, this.fovBase, this.fovMax);
                }
                else if (this.targetCamera.m_Lens.FieldOfView < this.fovBase)
                {
                    value = this.DeltaFOV;
                    IncrementedFOV = this.targetCamera.m_Lens.FieldOfView + value;
                    newFOV = Mathf.Clamp(IncrementedFOV, this.fovMin, this.fovBase);
                }
                else
                {
                    newFOV = this.fovBase;
                }
            }
                
            // Setze den neuen FOV-Wert
            this.targetCamera.m_Lens.FieldOfView = newFOV;
        }
    }
}