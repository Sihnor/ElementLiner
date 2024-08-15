using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Prog.Scripts.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float SpeedMultiplier = 10;
        private Vector3 MoveDirection;
        private Rigidbody Rigidbody;
        
        private void Awake()
        {
            this.Rigidbody = GetComponent<Rigidbody>();
            
            GetComponent<PlayerInput>().actions["Move"].performed += OnMoveStart;
            GetComponent<PlayerInput>().actions["Move"].canceled += OnMoveStop;
            
            GetComponent<PlayerInput>().actions["Slide"].performed += OnSlideStart;
            GetComponent<PlayerInput>().actions["Slide"].canceled += OnSlideStop;
            
        }

        private void OnMoveStart(InputAction.CallbackContext obj)
        {
            this.MoveDirection = obj.ReadValue<Vector2>() * this.SpeedMultiplier;
            if (this.MoveDirection.y < 0)
                this.MoveDirection.y = 0;
        }
        
        private void OnMoveStop(InputAction.CallbackContext obj)
        {
            this.MoveDirection = Vector3.zero;
        }

        private void OnSlideStart(InputAction.CallbackContext obj)
        {
        }

        private void OnSlideStop(InputAction.CallbackContext obj)
        {
        }


        private void FixedUpdate()
        {
            float velocityZ = this.Rigidbody.velocity.z;
            float velocityX = this.Rigidbody.velocity.x;
            float newVelocityForward = velocityZ + this.MoveDirection.y;
            float newVelocitySideways = velocityX + this.MoveDirection.x;
            
            this.Rigidbody.velocity = new Vector3(newVelocitySideways, this.Rigidbody.velocity.y, newVelocityForward);
        }
    }
}