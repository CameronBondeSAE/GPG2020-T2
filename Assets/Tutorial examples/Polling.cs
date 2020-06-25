using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Polling : MonoBehaviour
{
	public GameManager gameManager;
	private bool previousStarted;
	public int health;
	
	// Update is called once per frame
    void Update()
    {
		// POLLING BAD
		if (gameManager.started)
		{
			if (previousStarted != gameManager.started)
			{
				// Do something ONCE when it starts
			}

			previousStarted = gameManager.started;
		}
		
		// Events
		// NOTHING IN UPDATE YAY!
	}
}
