using System;
using UnityEngine;

namespace Prog.Scripts
{
    [CreateAssetMenu(fileName = "PlayerHealth", menuName = "ScriptableObject/Variables", order = 0)]
    public class PlayerHealth : ScriptableObject
    {
        private float health = 5;
        
        public event Action OnHealthChanged;
        
        public float Health
        {
            get => this.health;
            set
            {
                this.health = value;
                this.OnHealthChanged?.Invoke();
            }
        }
        
        public void TakeDamage(float damage)
        {
            this.Health -= damage;
        }
    }
}