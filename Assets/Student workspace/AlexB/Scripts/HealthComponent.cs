using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AJ
{
    public class HealthComponent : MonoBehaviour
    {
        public int MaxHealth;
        public int MinHealth;
        public int currentHealth;

		public UnityEvent<HealthComponent> deathEvent;

        public void AddHp(int amount)
        {
            currentHealth += amount;
        }

        public void TakeHp(int amount)
        {
            currentHealth -= amount;
            if( currentHealth <= 0)
            {
                Death();
            }
        }

        public void Death()
        {
            if(deathEvent!=null)
            {
                deathEvent.Invoke(this);
            }
            
            
        }
    }
}

