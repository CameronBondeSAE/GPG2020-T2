using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using alexM;
using AnthonyY;
using Mirror;
using Mirror.Examples.Pong;
using UnityEngine;

public class Nearby : MonoBehaviour
{
	public Transform                     origin;
	public List<PlayerControllerTopDown> players;

	public event Action PlayerListUpdated;


	public PlayerControllerTopDown GetClosest()
	{
		float                   closestDistance = 99999999f;
		PlayerControllerTopDown closestPlayer   = null;

		foreach (PlayerControllerTopDown playerControllerTopDown in players)
		{
			float distance = Vector3.Distance(origin.position, playerControllerTopDown.transform.position);

			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestPlayer   = playerControllerTopDown;
			}
		}

		return closestPlayer;
	}

	private void OnTriggerEnter(Collider other)
	{
		// Because the player's main collider isn't on the root GO, but he has other colliders
		if (other.gameObject.layer == LayerMask.NameToLayer("Gameplay relevant colliders"))
		{
			PlayerControllerTopDown playerControllerTopDown = other.transform.root.GetComponent<PlayerControllerTopDown>();

			if (playerControllerTopDown)
			{
				players.Add(playerControllerTopDown);
				PlayerListUpdated?.Invoke();
				
				Debug.Log("I have entered the trigger zone");
				Debug.Log(playerControllerTopDown.gameObject.name);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Gameplay relevant colliders"))
		{
			PlayerControllerTopDown playerControllerTopDown = other.transform.root.GetComponent<PlayerControllerTopDown>();

			if (playerControllerTopDown)
			{
				players.Remove(playerControllerTopDown);
				PlayerListUpdated?.Invoke();
				
				Debug.Log("I have exited the trigger zone");
				Debug.Log(playerControllerTopDown.gameObject.name);
			}
		}
	}
}