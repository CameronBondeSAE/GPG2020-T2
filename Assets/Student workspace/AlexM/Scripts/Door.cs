using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace alexM
{
    public class Door : MonoBehaviour
    {
        public UnityEvent openedEvent;
        public GameObject target;
        [HideInInspector] public Vector3 startPos, targetPos, doorPos;

         public bool isOpening;

        public GameObject door;
        //[HideInInspector] public bool targetReached;

        
        // Start is called before the first frame update
        void Awake()
        {
            startPos = door.transform.position;
            if (target != null)
            {
                targetPos =  target.transform.position;
            }
        }

        void SetTarget(GameObject tgt)
        {
            if (target != null)
            {
                target = tgt;
                targetPos = target.transform.position;
            }
        }

        public void Open()
        {
            if (!isOpening)
            {
                isOpening = true;
                Debug.Log("Opening...");
            }
            else
            {
                isOpening = false;
                Debug.Log("Closing...");
            }
            
            //Debug.Log("Im Opened");
        }

        public bool TargetReached()
        {
            float dist = Vector3.Distance(door.transform.position, target.transform.position);

            if (dist <= 0.25)
            {
                openedEvent?.Invoke();
                return true;
            }
            else
            {
                return false;    
            }
        }

        private void Update()
        {
            
            //Do move stuff here
            if (isOpening)
            {
                //lerp to targetPos
                door.transform.position = targetPos; //Vector3.Lerp(door.transform.position, targetPos, 0.1f * Time.deltaTime);
               // door.transform.position
            }
        }
    }
}