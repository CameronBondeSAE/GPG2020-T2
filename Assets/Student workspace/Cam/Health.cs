using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public float health;

	public void Die()
	{
		Debug.Log("CharacterBase DIE");
		Destroy(gameObject);
	}
}
