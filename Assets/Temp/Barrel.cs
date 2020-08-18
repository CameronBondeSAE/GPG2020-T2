using System.Collections;
using System.Collections.Generic;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;
using UnityEngine.InputSystem;

public class Barrel : MonoBehaviour, IPossessable
{
	public NetworkGamePlayer possessor { get; set; }

	public void Movement(Vector2 dir, InputAction.CallbackContext ctx)
	{
		throw new System.NotImplementedException();
	}

	public void Aiming(Vector2 pos, InputAction.CallbackContext ctx)
	{
		throw new System.NotImplementedException();
	}

	public void Fire(InputAction.CallbackContext ctx)
	{
		throw new System.NotImplementedException();
	}

	public void Jump(InputAction.CallbackContext ctx)
	{
		GetComponent<Rigidbody>().AddForce(0, 1000f, 0);
	}

	public void Interact(InputAction.CallbackContext ctx)
	{
		throw new System.NotImplementedException();
	}

	public void Action1(InputAction.CallbackContext ctx)
	{
		throw new System.NotImplementedException();
	}

	public void Action2(InputAction.CallbackContext ctx)
	{
		throw new System.NotImplementedException();
	}

	public void Action3(InputAction.CallbackContext ctx)
	{
		throw new System.NotImplementedException();
	}
}