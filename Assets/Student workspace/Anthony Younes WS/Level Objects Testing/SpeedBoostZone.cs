using System;
using System.Collections;
using System.Collections.Generic;
using alexM;
using Cinemachine;
using Mirror;
using UnityEngine;

namespace AnthonyY
{
    public class SpeedBoostZone : NetworkBehaviour
    {
        public PlayerControllerTopDown _player;
        public int triggerBoost;

        // Start is called before the first frame update
        void Start()
        {
            _player = _player.GetComponent<PlayerControllerTopDown>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (isServer)
            {
                _player.speed += triggerBoost;
                //collision.attachedRigidbody.AddForce(0,triggerBoost,0);
                Debug.Log("Entered the area");
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (isServer)
            {
                _player.speed -= triggerBoost;
                Debug.Log("Exited the area");
            }
            
        }
    }

}
