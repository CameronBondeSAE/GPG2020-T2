using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BollardUsingAnimatorStates : MonoBehaviour
{
	private Animator animator;
	
    // Start is called before the first frame update
    void Start()
	{
		animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		if (InputSystem.GetDevice<Keyboard>().tKey.wasPressedThisFrame)
		{
			animator.Play("Base Layer.TestStates", 0, 0.25f);
		}
		
		// Vector3.ProjectOnPlane()
		if (InputSystem.GetDevice<Keyboard>().tKey.wasPressedThisFrame)
		{
			animator.Play("Base Layer.TestStates", 0, 0.25f);
		}
		if (InputSystem.GetDevice<Keyboard>().tKey.wasPressedThisFrame)
		{
			animator.Play("Base Layer.TestStates", 0, 0.25f);
		}
	}
}
