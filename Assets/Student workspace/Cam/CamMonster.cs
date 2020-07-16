using AJ;
using UnityEngine;

public class CamMonster : CharacterBase
{
	public Animator animator;

	public bool shield;

	private void Start()
	{
		GetComponent<HealthComponent>().deathEvent.AddListener(Die);
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