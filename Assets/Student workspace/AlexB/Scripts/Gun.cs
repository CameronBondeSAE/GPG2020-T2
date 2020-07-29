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

        void Awake()
        {
            gameControls = new GameControls();
            gameControls.Enable();
            gameControls.InGame.Fire.performed += Shoot;
        }
        
        void Shoot(InputAction.CallbackContext context) 
        {
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            Debug.Log("I Shot");
        }
    }
}