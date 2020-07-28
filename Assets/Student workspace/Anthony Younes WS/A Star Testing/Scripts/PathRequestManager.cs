using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace AnthonyY
{
    public class PathRequestManager : MonoBehaviour
    {
        Queue<PathRequest> pathRequestQueue = new Queue<PathRequest>();
        //takes in the current pathRequest out of the Queue
        private PathRequest currentPathRequest;
        private static PathRequestManager instance;
        private Pathfinding pathfinding;

        private bool isProcessingPath;

        private void Awake()
        {
            instance = this;
            pathfinding = GetComponent<Pathfinding>();
        }

        public static void RequestPath(Vector3 pathStart, Vector3 pathEnd, Action<Vector3[], bool> callback)
        {
            //after a new request is made
           PathRequest newRequest = new PathRequest(pathStart,pathEnd,callback);
           //how you add stuff to a queue
           instance.pathRequestQueue.Enqueue(newRequest);
           instance.TryProcessNext();
        }
//see if it is currently processing a path
        void TryProcessNext()
        {
            if (!isProcessingPath && pathRequestQueue.Count > 0)
            {
                // how to get first item in the queue
                currentPathRequest = pathRequestQueue.Dequeue();
                isProcessingPath = true;
                pathfinding.StartFindPath(currentPathRequest.pathStart, currentPathRequest.pathEnd);
            }
        }
//Once we finish processing the path we are currently one, get the path and check if we have successfully gone to the next path
        public void FinishedProccessingPath(Vector3[] path, bool success)
        {
            currentPathRequest.callback(path, success);
            isProcessingPath = false;
            TryProcessNext();
        }

        class PathRequest
        {
            public Vector3 pathStart;
            public Vector3 pathEnd;
            public Action<Vector3[], bool> callback;

            public PathRequest(Vector3 _start, Vector3 _end, Action<Vector3[], bool> _callback)
            {
                pathStart = _start;
                pathEnd = _end;
                callback = _callback;
            }
        }

    }

}
