using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlatformWaypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    private int current = 0;
    public float speed;
    public float wpRadius = 1; //could miss center of missing gameObject so using a radius

    public enum MoveStatus
    {
        Random,
        NormalLooping,
    }

    [SerializeField] private MoveStatus currentType = MoveStatus.Random;
    private MoveStatus randomStatus = MoveStatus.Random;
    private MoveStatus looping = MoveStatus.NormalLooping;

    private void Awake()
    {
        //Random enum to start so gameplay aint always the same
        currentType = (MoveStatus) Random.Range(0, System.Enum.GetValues(typeof(MoveStatus)).Length);
    }

    void Update()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < wpRadius)// check the distance between the first waypoint to the next
        {
            switch (currentType)
            {
                case MoveStatus.Random: 
                    current = Random.Range(0, waypoints.Length); //move in a random way
                    break;
                case MoveStatus.NormalLooping:
                    current++; 
                    break;
            }

          

            if (current >= waypoints.Length) //go back to first waypoint when at last
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position,
            Time.deltaTime * speed); //move towards the next waypoint at the speed set
    }
    

    
}
