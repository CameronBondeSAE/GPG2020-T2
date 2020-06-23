using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace Student_workspace.Dylan.Scripts.JobTests
{
    public class JobTest : MonoBehaviour
    {
        public float valueToTest;
        private float startTime;
        [SerializeField] private bool useJobs;
        public int TimesToExecute;

        public int speed = 100;
        private JobHandle transformJobHandle;
        private TransformAccessArray transformAccessArray;
        private NativeArray<float> rotationArray;
        
        public int amountToSpawn;
        public GameObject prefab;
        public List<GameObject> listOfCubes;

        private void Start()
        {
            for (int i = 0; i < amountToSpawn; i++)
            {
                GameObject cube = Instantiate(prefab, new Vector3(0 + i, 0, 0), Quaternion.identity);
                listOfCubes.Add(cube);
            }
            
            rotationArray = new NativeArray<float>(listOfCubes.Count, Allocator.TempJob);
            transformAccessArray = new TransformAccessArray(listOfCubes.Count);
            
            for (int i = 0; i < listOfCubes.Count; i++)
            {
                transformAccessArray.Add(listOfCubes[i].transform);
            }
        }

        void Update()
        {
            startTime = Time.realtimeSinceStartup;
            
            // if (useJobs)
            // {
            //     DoExampleJob();
            // }
            // else
            // {
            //     ExpensiveFunction();
            // }

            if (useJobs)
            {
                DoTransformJob();
            }
            else
            {
                ExpensiveTransformFunction();
            }
        }

        private void ExpensiveFunction()
        {
            float valueA = 0f;

            for (int i = 0; i < TimesToExecute; i++)
            {
                valueA = math.exp10(math.sqrt(valueA));
            }

            Debug.Log(((Time.realtimeSinceStartup - startTime) * 1000f) + "ms");
        }

        private void ExpensiveTransformFunction()
        {
            for (int i = 0; i < listOfCubes.Count; i++)
            {
                listOfCubes[i].transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
        }

        private void DoTransformJob()
        {
            TransformJob transformjob = new TransformJob();
            transformjob.speed = speed;
            transformjob.deltaTime = Time.deltaTime;
            transformjob.rotationOfTransform = rotationArray;
            
            transformJobHandle = transformjob.Schedule(transformAccessArray);
            // JobHandle.ScheduleBatchedJobs();
            transformJobHandle.Complete();

            rotationArray.Dispose();
            transformAccessArray.Dispose();
            Debug.Log(((Time.realtimeSinceStartup - startTime) * 1000f) + "ms");
        }

        private struct TransformJob : IJobParallelForTransform
        {
            public float speed;
            public float deltaTime;
            public NativeArray<float> rotationOfTransform;


            public void Execute(int index, TransformAccess transform)
            {
                transform.position += new Vector3(0, rotationOfTransform[index] + speed * deltaTime,0);
                // rotationOfTransform[index] += speed * deltaTime;
            }
        }

        private void DoExampleJob()
        {
            NativeArray<float> resultArray = new NativeArray<float>(1, Allocator.TempJob);
            NativeList<char> resultLetter = new NativeList<char>(Allocator.TempJob);

            //one way
            //instantiate a job
            SimpleJob myJob = new SimpleJob();
            //then give instance some data
            //remember to give all variables in myJob a value
            myJob.valueA = valueToTest;
            myJob.result = resultArray;
            myJob.letters = resultLetter;
            //schedule the job
            //handle used to ensure job is done and to use for dependency's if needed
            JobHandle handle = myJob.Schedule();

            //can do other tasks on main thread if you need to


            //usually you dont call complete right away you use this
            //time to have the other tasks run parallel to your job
            //only after complete are you allowed to access the nativearray data
            handle.Complete();
            float resultValueA = resultArray[0];
            char[] resultWork = resultLetter.ToArray();
            // Debug.Log("Result A = " + resultValueA);
            Debug.Log("My name is " + resultWork);

            Debug.Log(((Time.realtimeSinceStartup - startTime) * 1000f) + "ms");

            //dont forget to dispose of the memory after your done
            resultArray.Dispose();
            resultLetter.Dispose();
        }

        private struct SimpleJob : IJob
        {
            //all fields need to be biltiable
            public float valueA;
            public NativeArray<float> result;
            public NativeList<char> letters;

            //in execute you put all the job logic
            public void Execute()
            {
                valueA = math.exp10(math.sqrt(valueA));

                result[0] = valueA;

                char letter1 = 'a';
                char letter2 = 'b';
                char letter3 = 'c';

                letters.Add(letter1);
                letters.Add(letter2);
                letters.Add(letter3);
            }
        }
    }
}