using System;
using AJ;
using UnityEngine;

public class DidSomethingCoolEventArgs : EventArgs
{
	public int things;
	public string stuff;
	public bool woo;
}

public class CamMonster : CharacterBase
{
	public Animator animator;

	public bool shield;


	
	// Using Action generics
	public event Action<object, EventArgs> didSomethingCool ;
	
	
	// Using manually defined delegate
	public delegate void DidSomethingCoolDelegate(object sender, EventArgs e);
	public event DidSomethingCoolDelegate DidSomethingCool;
	
	
	
	
	private void Start()
	{
		GetComponent<HealthComponent>().deathEvent.AddListener(Die);
		
		DidSomethingCool += OnDidSomethingCool;
	}

	private void OnDidSomethingCool(object sender, EventArgs e)
	{
		DidSomethingCoolEventArgs args = e as DidSomethingCoolEventArgs;
		Debug.Log(args.stuff);
	}

	private void OnDestroy()
	{
		GetComponent<HealthComponent>().deathEvent.RemoveListener(Die);
	}

	// Update is called once per frame
	void Update()
	{
		// TODO: Put in the real player distance (multiple players?)
		// animator.SetFloat("DistanceToPlayer", Vector3.Distance(transform.position, Vector3.zero));
		
		DidSomethingCool.Invoke(this, new DidSomethingCoolEventArgs
									  {
										  things = 5,
										  stuff  = "Cam",
										  woo    = true
									  });
	}


	public void Die(HealthComponent arg0)
	{
		if (!shield)
		{
			Debug.Log("CamMonster die");

			if (GetComponent<AudioSource>() != null)
			{
				GetComponent<AudioSource>().Play();
			}
			Destroy(gameObject);
		}
	}
}