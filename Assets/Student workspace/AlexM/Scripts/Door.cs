using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace alexM
{
    public class Door : MonoBehaviour
    {
        public GameObject target;
        [HideInInspector] public GameObject originalTarget;
        public Vector3 startPos, targetPos, doorPos;
        public float speed;
        public bool isOpening, isClosing;

        public GameObject door;
        
        public enum State
        {
            Opened,
            Closed
        }
        public State state = State.Closed;

        public UnityEvent openedEvent,openingEvent;
        public UnityEvent closedEvent, closingEvent;

        
        // Start is called before the first frame update
        void Awake()
        {
            originalTarget = target;
            startPos = door.transform.position;
            doorPos = startPos;
            // if (target != null)
            // {
            //     targetPos =  target.transform.position;
            // }
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
            if (!isOpening && !isClosing)
            {
                targetPos = target.transform.position;
                isOpening = true;
            }
            else
            {
                isOpening = false;
            }
        }

        public void Close()
        {
            if (!isClosing && !isOpening)
            {
                targetPos = startPos;
                isClosing = true;
            }
            else
            {
                isClosing = false;
            }
        }

        public bool TargetReached(Vector3 tgt)
        {
            var dist = Vector3.Distance(door.transform.position, tgt);
            doorPos = door.transform.position;
            if (dist <= 0.01f)
            {
                openedEvent?.Invoke();
                return true;
            }
            else
            {
                closedEvent?.Invoke();
                return false;    
            }
        }

        private void Update()
        {
            
            //Do move stuff here
            if (isOpening)
            {
                openingEvent?.Invoke();
                //lerp to targetPos
                door.transform.position = Vector3.MoveTowards(doorPos, targetPos, 1f * Time.deltaTime * speed);
               // door.transform.position
               
               if (TargetReached(target.transform.position))
               {
                   state = State.Opened;
                   isOpening = false;
               }
               
            }
            else if (isClosing)
            {
                closingEvent?.Invoke();
                //door.transform.position = Vector3.Lerp(door.transform.position, startPos, 1f * Time.deltaTime);
                door.transform.position = Vector3.MoveTowards(door.transform.position, startPos, 1f * Time.deltaTime * speed);
                
                if (TargetReached(startPos))
                {
                    state = State.Closed;
                    isClosing = false;
                }
            }
        }
    }
}