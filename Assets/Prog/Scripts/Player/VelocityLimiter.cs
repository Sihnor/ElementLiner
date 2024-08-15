using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Prog.Scripts.Player
{
    public class VelocityLimiter : MonoBehaviour
    {
        [SerializeField] private float MaxVelocityForward = 10;
        [SerializeField] private float CurrentVelocityForward = 0;
        [SerializeField] private float MaxVelocitySideways = 10;
        [SerializeField] private float CurrentVelocitySideways = 0;
        private Rigidbody Rigidbody;
        
        private void Awake()
        {
            this.Rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            float clampedVelocityForward = Mathf.Clamp(this.Rigidbody.velocity.x, -this.MaxVelocityForward, this.MaxVelocityForward);
            float clampedVelocitySideways = Mathf.Clamp(this.Rigidbody.velocity.z, -this.MaxVelocitySideways, this.MaxVelocitySideways);
            this.Rigidbody.velocity = new Vector3(clampedVelocityForward, this.Rigidbody.velocity.y, clampedVelocitySideways);
            
            this.CurrentVelocityForward = this.Rigidbody.velocity.z;
            this.CurrentVelocitySideways = this.Rigidbody.velocity.x;
        }
    }
}