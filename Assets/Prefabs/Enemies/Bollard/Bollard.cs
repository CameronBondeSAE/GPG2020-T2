using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bollard : MonoBehaviour
{
	Animation anim;

	private void Start()
	{
		anim                   = GetComponent<Animation>();
		anim["Shunt"].wrapMode = WrapMode.PingPong;
		anim.animatePhysics    = true;
		anim.playAutomatically = false;
	}

	void Update()
	{
		if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
		{
			anim.Play("Shunt");
		}
	}
}
