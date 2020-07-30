using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace AnthonyY
{
    public class NPCAVOID : NetworkBehaviour
    {
        // Start is called before the first frame update
        private Rigidbody rb;
        public float speed;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            rb.AddRelativeForce(0,0,speed);
        }
    }
}

