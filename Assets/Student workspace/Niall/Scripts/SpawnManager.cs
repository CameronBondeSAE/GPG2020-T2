using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using AJ;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnPrefab;
    private float posX;
    private float posZ;
    public float spawnAreaMin;
    public float spawnAreaMax;
    public bool spawnOnStart = false;
    
    [Tooltip("Next wave will begin after 'Wave Interval' timer reaches 0")]
    public bool timedWaves;
    
    [Tooltip("Next wave will begin when all enemies of current wave are destroyed.")]
    public bool completedWaves;

    private int monNum;
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


    public void Start()
    {
        if (spawnOnStart)
        {
            StartCoroutine(EnemySpawn());
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
        for (int wcounter = 0; wcounter < waveCount; wcounter++)
        {
            currentWave = wcounter;

            for (int counter = 0; counter < enemies; counter++)
            {
                monNum++;
                posX = Random.Range(spawnAreaMin, spawnAreaMax);
                posZ = Random.Range(spawnAreaMin, spawnAreaMax);
                GameObject newEnemy = Instantiate(spawnPrefab, transform.position + new Vector3(posX, 1, posZ),
                    Quaternion.identity);
               // Debug.Log( spawnPrefab.name + monNum + " " + "Spawned");
                units.Add(newEnemy);
                newEnemy.GetComponent<HealthComponent>()?.deathEvent.AddListener(RemoveFromList);
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

    

    private void RemoveFromList(HealthComponent arg0)
    {
        units.Remove(arg0.gameObject);

        if (currentWave == waveCount - 1 && units.Count <= 0)
        {
            wavesCompletedEvent?.Invoke();
        }
    }
}