using Niall;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class TrackingSystem : MonoBehaviour
    {
        public float speed = 3.0f;
        public GameObject target = null;
        Vector3 lastKnownPosition = Vector3.zero;
        Quaternion lookAtRotation;

        public LineOfSight lineOfSight;
        public Nearby nearby;

        private EventStateManager stateManager;
        public EventState SearchState;
        public EventState AttackState;

        private void Start()
        {
            stateManager = new EventStateManager();
            SearchState = new EventState();
            SearchState.Execute = SearchStateUpdate;
            AttackState = new EventState();
            AttackState.Execute = AttackStateUpdate;
            stateManager.ChangeState(SearchState);
        }

        private void Update()
        {
            
            stateManager.ExecuteCurrentState();
        }

        void SearchStateUpdate()
        {
            transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
            if (lineOfSight.haveLOS == true)
            {
                stateManager.ChangeState(AttackState);
            }

            if(nearby.GetClosest() != null)
            {
                lineOfSight.targets = new List<Transform>();

                lineOfSight.targets.Add(nearby.GetClosest().transform);
                
                if (lineOfSight.haveLOS == true)
                {
                    stateManager.ChangeState(AttackState);
                }
            }
            

        }

        // Update is called once per frame
        void AttackStateUpdate()
        {
            //make target = nearby
            if (target)
            {
                if (lastKnownPosition != target.transform.position)
                {
                    lastKnownPosition = target.transform.position;
                    lookAtRotation = Quaternion.LookRotation(lastKnownPosition - transform.position);
                }
                if (transform.rotation != lookAtRotation)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, speed * Time.deltaTime);
                }
            }

            if (nearby.GetClosest() == null)
            {
                stateManager.ChangeState(SearchState);
            }
        }

        private bool SetTarget(GameObject target)
        {
            if (target)
            {
                return false;
            }

            target = target;

            return true;
        }
    }
}