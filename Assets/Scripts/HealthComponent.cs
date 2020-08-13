using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AJ
{
    public class HealthComponent : MonoBehaviour
    {
        public int MaxHealth = 100;
        public int currentHealth = 100;

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

