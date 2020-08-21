using System;
using System.Collections;
using System.Collections.Generic;
using alexM;
using AnthonyY;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    
    public Transform target;
    public float speed = 1;
    public Vector3[] path;
    public int targetIndex;
    public bool constantRecalculate;
    public WaypointMovement waypointMovement;

    private void Awake()
    {
        waypointMovement.TargetChanged += ReCalculatePath;
    }

    private void ReCalculatePath(Transform obj)
    {
        PathRequestManager.RequestPath(transform.position,obj.position, OnPathFound);
        Debug.Log(obj.position.ToString());
    }

    private void Update()
    {
        if (constantRecalculate == true)
        {
           RecalculatePathHack();
        }
    }

    public void RecalculatePathHack() {
        PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
        if (pathSuccessful) {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath() {
        if (path != null)
        {
            Vector3 currentWaypoint = path[0];
            while (true) {
                if (transform.position == currentWaypoint) {
                    targetIndex ++;
                    if (targetIndex >= path.Length)
                    {
                        targetIndex = 0;
                        path = new Vector3[0];
                        yield break;
                    }
                    currentWaypoint = path[targetIndex];
                }

                transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);
                yield return null;

            }
        }
    }

    public void OnDrawGizmos() {
        if (path != null) {
            for (int i = targetIndex; i < path.Length; i ++) {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex) {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else {
                    Gizmos.DrawLine(path[i-1],path[i]);
                }
            }
        }
    }
}
