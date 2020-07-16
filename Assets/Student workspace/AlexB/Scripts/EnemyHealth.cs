using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AJ
{
    
    public class EnemyHealth : MonoBehaviour
    {
        public int enemyHealth = 100;
        public void DeductHealth(int deductHealth)
        {
            enemyHealth -= deductHealth;

            //if (enemyHealth <= 0) { Death(); }
        }
    }
}
