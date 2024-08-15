using System;
using Prog.Scripts.Enums;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Prog.Scripts.Player
{
    public class ElementSwitch : MonoBehaviour
    {
        [SerializeField] private EElement currentElementIndex = EElement.Fire;
        [SerializeField] private PlayerHealth PlayerHealth;
        
        private void Awake()
        {
            GetComponent<PlayerInput>().actions["PreviousElement"].performed += OnPreviousElement;
            GetComponent<PlayerInput>().actions["NextElement"].performed += OnNextElement;
        }

        private void Start()
        {
            this.currentElementIndex = EElement.Fire;
        }

        private void OnNextElement(InputAction.CallbackContext obj)
        {
            this.currentElementIndex++;
            if ((int) this.currentElementIndex > 3)
            {
                this.currentElementIndex = EElement.Fire;
            }
            
        }

        private void OnPreviousElement(InputAction.CallbackContext obj)
        {
            this.currentElementIndex--;
            if ((int) this.currentElementIndex < 0)
            {
                this.currentElementIndex = EElement.Air;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            bool tookDamage = false;
            if (other.gameObject.CompareTag("FireElement") && this.currentElementIndex != EElement.Fire)
            {
                Debug.Log("You are not the fire element");
                tookDamage = true;
            }
            
            if (other.gameObject.CompareTag("EarthElement") && this.currentElementIndex != EElement.Earth)
            {
                Debug.Log("You are not the earth element");
                tookDamage = true;
            }
            
            if (other.gameObject.CompareTag("WaterElement") && this.currentElementIndex != EElement.Water)
            {
                Debug.Log("You are not the water element");
                tookDamage = true;
            }
            
            if (other.gameObject.CompareTag("AirElement") && this.currentElementIndex != EElement.Air)
            {
                Debug.Log("You are not the air element");
                tookDamage = true;
            }

            if (other.gameObject.CompareTag("OtherObstacle"))
            {
                Debug.Log("You hit an obstacle");
                tookDamage = true;
            }
            
            if (tookDamage) this.PlayerHealth.TakeDamage(1);
            
            other.gameObject.SetActive(false);
        }
    }
}