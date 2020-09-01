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

        private EventStateManager stateManager;
        public EventState SearchState;
        public EventState AttackState;

        private void Start()
        {
            stateManager = new EventStateManager();
            SearchState = new EventState();
            SearchState.Execute = SearchStateUpdate;
            stateManager.ChangeState(SearchState);
        }

        private void Update()
        {
            stateManager.ExecuteCurrentState();
        }

        void SearchStateUpdate()
        {
            stateManager.ChangeState(AttackState);
        }

        // Update is called once per frame
        void AttackStateUpdate()
        {
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