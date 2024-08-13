using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Prog.Scripts.Player
{
    public class Movement : MonoBehaviour
    {
        private Vector3 MoveDirection;
        private Rigidbody Rigidbody;
        
        [SerializeField, Range(0, 10)] private float JumpHeight = 10;

        private void Awake()
        {
            this.Rigidbody = GetComponent<Rigidbody>();
            
            GetComponent<PlayerInput>().actions["Move"].performed += OnMoveStart;
            GetComponent<PlayerInput>().actions["Move"].canceled += OnMoveStop;
            
            GetComponent<PlayerInput>().actions["Jump"].performed += OnJumpStart;
            GetComponent<PlayerInput>().actions["Jump"].canceled += OnJumpStop;
            
            GetComponent<PlayerInput>().actions["Slide"].performed += OnSlideStart;
            GetComponent<PlayerInput>().actions["Slide"].canceled += OnSlideStop;
            
        }

        private void OnMoveStart(InputAction.CallbackContext obj)
        {
            this.MoveDirection = obj.ReadValue<Vector2>() * 10;
            if (this.MoveDirection.y < 0)
                this.MoveDirection.y = 0;
        }
        
        private void OnMoveStop(InputAction.CallbackContext obj)
        {
            this.MoveDirection = Vector3.zero;
        }
        
        private void OnJumpStart(InputAction.CallbackContext obj)
        {
        }
        
        private void OnJumpStop(InputAction.CallbackContext obj)
        {
        }


        private void OnSlideStart(InputAction.CallbackContext obj)
        {
        }

        private void OnSlideStop(InputAction.CallbackContext obj)
        {
        }


        private void FixedUpdate()
        {
            //this.Rigidbody.AddForce(this.MoveDirection.x, this.Rigidbody.velocity.y, this.MoveDirection.y);
        }
    }
}