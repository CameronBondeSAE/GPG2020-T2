using Niall;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class TrackingSystem : MonoBehaviour
    {
        public float speed = 3.0f;
        Vector3 lastKnownPosition = Vector3.zero;
        Quaternion lookAtRotation;
        bool hasTarget = false;
        public LineOfSight lineOfSight;
        public Nearby nearby;

        private EventStateManager stateManager;
        public EventState SearchState;
        public EventState AttackState;
        bool isFiring;
        public GameObject bulletPrefab;
        public Transform gunBarrel;
        public float bulletSpeed = 10f;
        public float rateOfFire = .5f;
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
            
			if(nearby.GetClosest() != null)
            {
				lineOfSight.singleTarget = nearby.GetClosest().transform;
                
                if (lineOfSight.CheckLOS() == true)
                {
                    stateManager.ChangeState(AttackState);
                }
            }
		}

        // Update is called once per frame
        void AttackStateUpdate()
        {
            //make target = nearby
            if (lineOfSight.singleTarget)
            {
                if (lastKnownPosition != lineOfSight.singleTarget.transform.position)
                {
                    lastKnownPosition = lineOfSight.singleTarget.transform.position;
                    lookAtRotation = Quaternion.LookRotation(lastKnownPosition - transform.position);
                }
                if (transform.rotation != lookAtRotation)
                {
                    hasTarget = true;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, speed * Time.deltaTime);
                    while(hasTarget && !isFiring)
                    {
                        StartCoroutine(ShootBullet());
                    }
                }                
            }            

            if (nearby.GetClosest() == null)
            {
                stateManager.ChangeState(SearchState);
            }
        }

        private IEnumerator ShootBullet()
        {
            isFiring = true;
            yield return new WaitForSeconds(rateOfFire);
            GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
            isFiring = false;
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