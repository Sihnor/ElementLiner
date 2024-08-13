using System;
using UnityEngine;

namespace Prog.Scripts.Player
{
    public class VelocityLimiter : MonoBehaviour
    {
        private Rigidbody Rigidbody;
        
        private void Awake()
        {
            this.Rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            float ClampedVelocity = Mathf.Clamp(this.Rigidbody.velocity.y, -10, 10);
            this.Rigidbody.velocity = new Vector3(this.Rigidbody.velocity.x, ClampedVelocity, this.Rigidbody.velocity.z);
        }
    }
}