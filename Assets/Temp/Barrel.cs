using System.Collections;
using System.Collections.Generic;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;

public class Barrel : MonoBehaviour, IPossesable
{
	public NetworkGamePlayer posessor { get; set; }

	public void Movement(Vector2 dir)
	{
	}

	public void Aiming(Vector2 pos)
	{
	}

	public void Fire()
	{
	}

	public void Jump()
	{
		GetComponent<Rigidbody>().AddForce(0,1000f,0);
	}

	public void Interact()
	{
	}

	public void Action1()
	{
	}

	public void Action2()
	{
	}

	public void Action3()
	{
	}
}