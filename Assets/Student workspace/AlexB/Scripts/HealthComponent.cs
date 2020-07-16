using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class HealthComponent : MonoBehaviour
    {
        public int currentMaxHealth;
        public int currentMinHealth;
        public int currentHealth;
        

        public void AddHp()
        {
            currentHealth++;
        }

        public void TakeHp()
        {
            currentHealth--;
        }

        public void EnemyDeath()
        {
            //deathEvent.Invoke();
            Destroy(gameObject);
        }
    }
}

