using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWaypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    private int current = 0;
    public float speed;
    public float wpRadius = 1; //could miss center of missing gameObject so using a radius

    void Update()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < wpRadius)// check the distance between the first waypoint to the next
        {
            current = Random.Range(0, waypoints.Length); //move in a random way
            if (current >= waypoints.Length) //go back to first waypoint when at last
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position,
            Time.deltaTime * speed); //move towards the next waypoint at the speed set
    }

}
