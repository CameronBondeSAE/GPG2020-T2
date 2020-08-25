using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall
{

    public class PathRequestMgr : MonoBehaviour
    {
        
        Queue<PathRequest> pathRequestQueue = new Queue<PathRequest>();
        private PathRequest currentPathRequest;

        private static PathRequestMgr instance;
        private Pathfinding pathfinding;

        private bool isProcessingPath;

        void Awake()
        {
            instance = this;
            pathfinding = GetComponent<Pathfinding>();
        }
        public static void RequestPath(Vector3 pathStart, Vector3 pathEnd, Action<Vector3[], bool> callback)
        {
            PathRequest newRequest = new PathRequest(pathStart,pathEnd,callback);
            instance.pathRequestQueue.Enqueue(newRequest);
            instance.TryProcessNext();
        }

        public void TryProcessNext()
        {
            if (!isProcessingPath && pathRequestQueue.Count > 0)
            {
                currentPathRequest = pathRequestQueue.Dequeue();
                isProcessingPath = true;
                pathfinding.StartFindPath(currentPathRequest.pathStart, currentPathRequest.pathEnd);
            }
        }

        public void FinishedProcessingPath(Vector3[] path, bool success)
        {
            currentPathRequest.callback(path, success);
            isProcessingPath = false;
            TryProcessNext();
        }

        struct PathRequest
        {
            public Vector3 pathStart;
            public Vector3 pathEnd;
            public Action<Vector3[], bool> callback;

            public PathRequest(Vector3 start, Vector3 end, Action<Vector3[], bool> _callback)
            {
                pathStart = start;
                pathEnd = end;
                callback = _callback;
            }
        }
    }
}
