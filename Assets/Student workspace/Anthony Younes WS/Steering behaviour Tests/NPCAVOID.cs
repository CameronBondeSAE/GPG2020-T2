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
        void FixedUpdate()
        {
			if (isServer)
			{
				rb.AddRelativeForce(0, 0, speed);
			}
        }
        
        void OnCollisionEnter(Collision other)
        {
			if (isServer)
			{
				other.gameObject?.GetComponent<PlayerControllerTopDown>()?.GetComponent<HealthComponent>()?.TakeHp(damageAmount);
				Debug.Log("I done damage to the player!!");
			}
        }

        void Death()
        {
			if (isServer)
			{
				gameObject.GetComponent<HealthComponent>()?.Death();
				Debug.Log("player Deadd");
			}
        }
    }
}

