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
    private int enemyCount = 0;
    public int enemies = 2;
    public bool spawn;
    public float spawnInterval = 0.1f;

    public InputMaster controls;



    public void Update()
    {
      //  if (enemyCount >= 5)
      //  {
      //      enemies = 5;
      //  }
    }  
    
    public void SpawnAll()
         {
             StartCoroutine(EnemySpawn());
         }


    public IEnumerator EnemySpawn()
    {
        for (int counter = 0; counter < enemies; counter++)
        {
            posX = Random.Range(-5f, 5f);
            posZ = Random.Range(-5f, 5f);
            Instantiate(enemy, new Vector3(posX, 1, posZ), Quaternion.identity);
            enemyCount += 1;
            Debug.Log(counter + "Spawned");
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}