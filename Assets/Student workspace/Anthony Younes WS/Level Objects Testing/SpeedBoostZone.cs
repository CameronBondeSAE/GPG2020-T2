using System;
using System.Collections;
using System.Collections.Generic;
using alexM;
using Cinemachine;
using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
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
            Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider collision)
        {
            _player.speed += triggerBoost;
            //collision.attachedRigidbody.AddForce(0,triggerBoost,0);
            Debug.Log("Entered the area");
        }

        private void OnTriggerExit(Collider other)
        {
            _player.speed -= triggerBoost;
            Debug.Log("Exited the area");
        }


    }
}
