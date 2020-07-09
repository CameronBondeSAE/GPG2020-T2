using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToKill : MonoBehaviour
{
    void Update()
	{
		Vector2 mousePosition = InputSystem.GetDevice<Mouse>().position.ReadValue();

		Ray ray = Camera.main.ScreenPointToRay(mousePosition);

		RaycastHit hitInfo;
		if (Physics.Raycast(ray, out hitInfo) && InputSystem.GetDevice<Mouse>().leftButton.wasPressedThisFrame)
		{
			// Note the question mark, which is just a shortcut for checking for null (ie did we find the right thing with GetComponent?)
			// Also once you pick a strategy, you'd only have one line interacting with a health component
			hitInfo.collider.gameObject.GetComponent<HealthUsingEvents>()?.Die();
			hitInfo.collider.gameObject.GetComponent<HealthUsingInheritance>()?.Die();
		}
	}
}
