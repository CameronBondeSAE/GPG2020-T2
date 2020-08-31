using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using alexM;
using AnthonyY;
using Mirror.Examples.Pong;
using UnityEngine;

public class Nearby : MonoBehaviour
{
    public PlayerControllerTopDown[] players;
    private void Start()
    {
        players = FindObjectsOfType<PlayerControllerTopDown>();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        foreach (PlayerControllerTopDown player in players)
        {
            Debug.Log("I have entered the trigger zone");
            Debug.Log(player.gameObject.name);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (PlayerControllerTopDown player in players)
        {
            Debug.Log("I have entered the trigger zone");
        }
    }
} 