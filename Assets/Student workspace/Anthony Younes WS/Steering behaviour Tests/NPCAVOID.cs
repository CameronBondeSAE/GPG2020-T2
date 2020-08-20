using System.Collections;
using System.Collections.Generic;
using AJ;
using alexM;
using Mirror;
using UnityEngine;

namespace AnthonyY
{
    public class NPCAVOID : NetworkBehaviour
    {
        // Start is called before the first frame update
        private Rigidbody rb;
        public float speed;

		public int damageAmount = 20;
		
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            rb.AddRelativeForce(0,0,speed);
        }
        
        void OnCollisionEnter(Collision other)
        {
			other.gameObject?.GetComponent<PlayerControllerTopDown>()?.GetComponent<HealthComponent>()?.TakeHp(damageAmount);
            Debug.Log("I done damage to the player!!");
        }

        void Death()
        {
            gameObject.GetComponent<HealthComponent>()?.Death();
            Debug.Log("player Deadd");
        }
    }
}

