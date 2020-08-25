using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class TrackingSystem : MonoBehaviour
    {
        public float speed = 3.0f;
        public GameObject m_target = null;
        Vector3 lastKnownPosition = Vector3.zero;
        Quaternion lookAtRotation;

		void SearchState()
		{
			
		}
		
        void AttackState()
        {
            if (m_target)
            {
                if (lastKnownPosition != m_target.transform.position)
                {
                    lastKnownPosition = m_target.transform.position;
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

            m_target = target;

            return true;
        }
    }
}