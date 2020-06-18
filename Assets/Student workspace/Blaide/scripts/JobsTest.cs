using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Mathematics;
using Random = UnityEngine.Random;

namespace Student_workspace.Blaide.scripts
{
    /// <summary>
    /// This is just my test script for the unity jobs system. essentially i'll create a job that does some heavy load of math/work. and then i will create and schedule a bunch of instances of that job and it shouldn't freeze up unity.
    /// </summary>
    public class JobsTest : MonoBehaviour
    {
        public GameObject ObjPrefab;
        public int objCount;
        public Transform[] transforms;

        private TransformAccessArray t;
        private JobHandle _jobHandle1;
        private TestTransformJob testTransformJob;
        private bool completeflag;
        // Start is called before the first frame update
        void Start()
        {
            

            testTransformJob.time = Time.time;
            transforms = new Transform[objCount];
            for (int i = 0; i < transforms.Length; i++)
            {
                GameObject g = Instantiate(ObjPrefab, transform.position + new Vector3(i, 1, 1), transform.rotation);
                
                transforms[i] = g.transform;
            }
            t = new TransformAccessArray(transforms);
             _jobHandle1 = testTransformJob.Schedule(t);
            /*TestJob testJob1;            JobHandle1 = testJob1.Schedule();*/
            
        }

        // Update is called once per frame
        void Update()
        {
            if (_jobHandle1.IsCompleted)
            {
                _jobHandle1.Complete();
                 t.Dispose();
                 testTransformJob.time = Time.time;
                t = new TransformAccessArray(transforms);
                _jobHandle1 = testTransformJob.Schedule(t);
            }
        }

        private void OnDisable()
        {
            t.Dispose();
        }
    }

    public struct TestJob : IJob
    {
        public void Execute()
        {
            float f = 1.2f;
            for (int i = 0; i < 1000000; i++)
            {
                f += 29 * math.sqrt(noise.cnoise(new float2(0.1f,1)));
            }
            Debug.Log(f);
        }
    }

    public struct TestTransformJob : IJobParallelForTransform
    {
        public float time;
        public void Execute(int index, TransformAccess transform)
        {
            transform.position = new Vector3(transform.position.x, 5* noise.cnoise(new float2(time + (index * 0.1f),1)),transform.position.z);
        }
    }
}