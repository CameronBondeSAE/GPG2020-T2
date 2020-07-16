using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AJ
{
    [CustomEditor(typeof(HealthComponent))]
    public class EnemyHealth : HealthComponent
    {
        public int enemyHealth = 100;
        public void DeductHealth(int deductHealth)
        {
            enemyHealth -= deductHealth;

            if (enemyHealth <= 0) { EnemyDeath(); }
        }
    }
}
