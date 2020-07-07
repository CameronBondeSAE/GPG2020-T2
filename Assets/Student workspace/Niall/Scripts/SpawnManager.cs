using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    private float posX;
    private float posZ;
    public float spawnAreaMin;
    public float spawnAreaMax;
    public int enemies = 2;
    public bool spawn;
    private float spawnInterval = 0.1f;
    private int monNum;

    public InputMaster controls;


    public void Start()
    {
       if (spawn)
       {StartCoroutine(EnemySpawn());}
    }
    
    public void SpawnAll()
         {
             StartCoroutine(EnemySpawn());
         }


    public IEnumerator EnemySpawn()
    {
        for (int counter = 0; counter < enemies; counter++)
        {
            monNum++;
            posX = Random.Range(spawnAreaMin, spawnAreaMax);
            posZ = Random.Range(spawnAreaMin, spawnAreaMax);
            Instantiate(enemy, transform.position + new Vector3(posX, 1, posZ), Quaternion.identity);
            Debug.Log(monNum + "Spawned");
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}