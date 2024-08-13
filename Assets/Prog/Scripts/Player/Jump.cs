using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Prog.Scripts.Player
{
    public class Jump : MonoBehaviour
    {
        private Rigidbody Rigidbody;

        private bool IsJumping;
        [SerializeField, Range(0, 10)] private float JumpHeight = 10;
        [SerializeField, Range(0, 5)] private float JumpDuration = 2;
        private bool IsSecondJump = false;
        
        private void Awake()
        {
            this.Rigidbody = GetComponent<Rigidbody>();
            
            GetComponent<PlayerInput>().actions["Jump"].started += OnJumpStart;
            GetComponent<PlayerInput>().actions["Jump"].canceled += OnJumpStop;
        }

        private void FixedUpdate()
        {
            if (Physics.Raycast(transform.position, Vector3.down, 1.1f)) this.IsSecondJump = false;
        }

        private void OnJumpStart(InputAction.CallbackContext obj)
        {
            // Player standing on the ground
            if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
            {
                StartCoroutine(JumpCharacter());
                return;
            }
            
            if (this.IsSecondJump) return;
            
            this.IsSecondJump = true;            
            
            StartCoroutine(JumpCharacter());
        }

        private void OnJumpStop(InputAction.CallbackContext obj)
        {
            StopAllCoroutines();
        }
        
        
        // Die Funktion, die wir umschreiben möchten
        public static float EaseOutQuint(float x)
        {
            // Berechnet den EaseOutQuint-Wert basierend auf der Eingabe x
            return 1 - Mathf.Pow(1 - x, 5);
        }

        IEnumerator JumpCharacter()
        {
            Vector3 originalPosition = transform.position;
            Vector3 endPosition = originalPosition + Vector3.up * this.JumpHeight;
            float elapsedTime = 0;

            while (elapsedTime < this.JumpDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / this.JumpDuration;
                float easedT = EaseOutQuint(t);
                transform.position = Vector3.Lerp(originalPosition, endPosition, easedT);
                yield return null;
            }
            
            transform.position = endPosition;
        }
    }
}