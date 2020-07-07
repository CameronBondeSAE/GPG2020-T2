using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMonster : CharacterBase
{
	public Animator animator;

	public bool shield;
	
    // Update is called once per frame
    void Update()
	{
		// TODO: Put in the real player distance (multiple players?)
        // animator.SetFloat("DistanceToPlayer", Vector3.Distance(transform.position, Vector3.zero));
    }


	public void Die()
	{
		if (!shield)
		{
			Debug.Log("CamMonster die");

			GetComponent<AudioSource>().Play();
			Destroy(gameObject);
		}
	}
}
