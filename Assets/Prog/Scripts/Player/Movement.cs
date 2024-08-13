using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Prog.Scripts.Player
{
    public class Movement : MonoBehaviour
    {

        private void Awake()
        {
            GetComponent<PlayerInput>().actions["Move"].started += OnMoveStart;
            GetComponent<PlayerInput>().actions["Move"].canceled += OnMoveStop;
            
            GetComponent<PlayerInput>().actions["Jump"].started += OnJumpStart;
            GetComponent<PlayerInput>().actions["Jump"].canceled += OnJumpStop;
            
            GetComponent<PlayerInput>().actions["Slide"].performed += OnSlideStart;
            GetComponent<PlayerInput>().actions["Slide"].canceled += OnSlideStop;
            
        }

        private void OnSlideStop(InputAction.CallbackContext obj)
        {
            throw new NotImplementedException();
        }

        private void OnJumpStop(InputAction.CallbackContext obj)
        {
            throw new NotImplementedException();
        }

        private void OnMoveStop(InputAction.CallbackContext obj)
        {
            throw new NotImplementedException();
        }

        private void OnSlideStart(InputAction.CallbackContext obj)
        {
            throw new NotImplementedException();
        }

        private void OnJumpStart(InputAction.CallbackContext obj)
        {
            throw new NotImplementedException();
        }

        private void OnMoveStart(InputAction.CallbackContext obj)
        {
            throw new NotImplementedException();
        }
    }
}