using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AJ
{
    public class AJPlayer : MonoBehaviour
    {
        public HealthBar healthBar;
        public HealthComponent health;

        private void Awake()
        {
            healthBar.SetMaxHealth(health.MaxHealth);            
        }

        void TakeDamage()
        {
            health.TakeHp(2);
        }

        void Update()
        {   
            //Need to turn into event later
            healthBar.SetHealth(health.currentHealth);          
        }       
    }
}

