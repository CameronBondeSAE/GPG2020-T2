using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AJ
{
    public class AJPlayer : MonoBehaviour
    {

        public int maxHealth = 100;
        public int currentHealth;

        public HealthBar healthBar;

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        // Update is called once per frame
        void Update()
        {
            if (InputSystem.GetDevice<Keyboard>().spaceKey.IsPressed())
            {
                TakeDamage(2);
            }
        }

        void TakeDamage(int damage)
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }
    }
}

