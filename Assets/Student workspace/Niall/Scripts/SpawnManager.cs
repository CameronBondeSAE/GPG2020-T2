using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    private float posX;
    private float posZ;
    private int enemyCount;
    public int enemies;
    public bool spawn;
    public InputMaster controls;

    private void Start()
    {
        
    }

    public void Update()
    {
        if (enemyCount >= enemies)
        {
            spawn = false;
        }

        if (enemyCount <= 0 && spawn == false)
        {
            spawn = true;
        }
        
        EnemySpawn();
    }


    public void EnemySpawn()
    {
        if (spawn)
        {
            posX = Random.Range(-5f, 5f);
            posZ = Random.Range(-5f, 5f);
            Instantiate(enemy, new Vector3(posX, 1, posZ), Quaternion.identity);
            enemyCount += 1;
        }
    }
}