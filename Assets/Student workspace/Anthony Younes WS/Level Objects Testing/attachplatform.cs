using System;
using System.Collections;
using System.Collections.Generic;
using alexM;
using Mirror.Examples.Pong;
using UnityEngine;

public class attachplatform : MonoBehaviour
{
    public PlayerControllerTopDown player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //then player is on the platform
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
       if(other.gameObject == player)
       {
           //then player is not on the platform
           player.transform.parent = null;
       }
       
    }
}
