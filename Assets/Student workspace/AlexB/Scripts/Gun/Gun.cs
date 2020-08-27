using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AJ
{
    public class Gun : MonoBehaviour
    {
        public GameObject bullet;
        public Transform bulletSpawn;
        private GameControls gameControls;
        //public Player player;
        public ColourChanger colourChanger;

		public bool debugInput = false;
        private bool isServer;

        void Awake()
        {
            if(isServer)
            {
                if (debugInput)
                {
                    gameControls = new GameControls();
                    gameControls.Enable();
                    gameControls.InGame.Fire.performed += Shoot;
                }
            }
			
        }
        
        public void Shoot(InputAction.CallbackContext context) 
        {
            if(isServer)
            {
                GameObject bulletPrefab = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                Debug.Log("I Shot");
                // TODO, use ColourChanger for this (so we don't have to fix things in 50 different spots)
                bulletPrefab.GetComponent<Renderer>().sharedMaterial.color = colourChanger.currentColor;
            }
            
        }     
    }
}