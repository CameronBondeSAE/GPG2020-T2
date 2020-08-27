using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using AJ;
using Mirror;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class SpawnManager : NetworkBehaviour
{
	public  GameObject spawnPrefab;
	private float      posX;
	private float      posZ;
	public  float      spawnAreaMin;
	public  float      spawnAreaMax;
	public  bool       spawnOnStart = false;

//	[Tooltip("Next wave will begin after 'Wave Interval' timer reaches 0")]
	private bool timedWaves = false;

//	[Tooltip("Next wave will begin when all enemies of current wave are destroyed.")]
	private bool completedWaves = false;

	[Tooltip("0 : Timed Waves (Next wave will begin after 'Wave Interval' timer reaches 0)" + "                                                  " + 
	         "1 : Completed Waves (Next wave will begin when all enemies of current wave are destroyed)")]
	public int WaveType;

	//private int monNum;
	private int currentWave;

	public UnityEvent wavesCompletedEvent;

	[Header("Debug")]
	public List<GameObject> units = new List<GameObject>();


	[Header("Enemies")]
	public int enemies;

	public float spawnInterval = 0f;

	[Header("Waves")]
	public int waveCount = 3;

	public float waveInterval = 5f;


	public override void OnStartServer()
	{
		base.OnStartServer();

		if (spawnOnStart)
		{
			StartCoroutine(EnemySpawn());
		}
	}

	void Start()
	{
		if (WaveType == 0)
		{
			completedWaves = false;
			timedWaves = true;
		}

		if (WaveType == 1)
		{
			timedWaves = false;
			completedWaves = true;
		}

		if (WaveType >= 2)
		{
			WaveType = 1;
		}

		if (WaveType <= -1)
		{
			WaveType = 0;
		}
	}


	public void SpawnAll()
	{
		StartCoroutine(EnemySpawn());
	}

	public void KillAll()
	{
		List<GameObject> tempUnits = new List<GameObject>(units);
		foreach (var newEnemy in tempUnits)
		{
			newEnemy?.GetComponent<HealthComponent>().Death();
		}
	}


	public IEnumerator EnemySpawn()
	{
		// Server
		if (isServer)
		{
			Debug.Log("Spawn", this);
			for (int wcounter = 0; wcounter < waveCount; wcounter++)
			{
				currentWave = wcounter;

				for (int counter = 0; counter < enemies; counter++)
				{
					//monNum++;
					posX = Random.Range(spawnAreaMin, spawnAreaMax);
					posZ = Random.Range(spawnAreaMin, spawnAreaMax);
					GameObject newEnemy = Instantiate(spawnPrefab, transform.position + new Vector3(posX, 1, posZ), Quaternion.identity);
					// Debug.Log( spawnPrefab.name + monNum + " " + "Spawned");
					units.Add(newEnemy);
					newEnemy.GetComponent<HealthComponent>()?.deathEvent.AddListener(RemoveFromList);
					
					// Networking
					NetworkServer.Spawn(newEnemy);
					
					
					yield return new WaitForSeconds(spawnInterval);
				}

				if (timedWaves)
				{
					yield return new WaitForSeconds(waveInterval);
				}

				if (completedWaves)
				{
					while (units.Count > 0)
					{
						yield return null;
					}

					yield return new WaitForSeconds(waveInterval);
				}
			}
		}
	}


	private void RemoveFromList(HealthComponent arg0)
	{
		units.Remove(arg0.gameObject);

		if (currentWave == waveCount - 1 && units.Count <= 0)
		{
			wavesCompletedEvent?.Invoke();
		}
	}
}