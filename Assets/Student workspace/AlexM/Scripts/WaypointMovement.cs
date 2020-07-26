using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace alexM
{
    public class WaypointMovement : MonoBehaviour
    {
        public bool targetReached;
        public List<Waypoint> points;
        public float targetReachedThreshold;
        public Transform target;
        
        private enum MoveType
        {
            Ordered,
            Random,
            LoopBetween
        }

        [SerializeField]private MoveType _currentType;
        [SerializeField]private int _targetId;
        private int _maxCount;
        private Vector3 _dir;
        private void Awake()
        {
            if (!target)
            {
                _targetId = 0;
                target = points[_targetId].transform;
            }
            
            _currentType = MoveType.Ordered;
            _dir = (target.position - transform.position).normalized;
        }

        bool distCheck()
        {
            if (target != null)
            {
                float dist = Vector3.Distance(gameObject.transform.position, target.position);
                if (dist < targetReachedThreshold)
                {
                    return true;
                    //target Reached
                }
                else
                {
                    return false;
                    //Not Reached
                }
            }
            else
            {
                return false;
            }
        }

        void SelectTarget()
        {
            switch (_currentType)
            {
                case MoveType.Ordered:
                    //Debug.Log("Set to Ordered");
                    _targetId++;
                    break;
                case MoveType.Random:
                    //Debug.Log("Set to Random");
                    break;
                case MoveType.LoopBetween:
                    //Debug.Log("Set to LoopBetween");
                    break;
            }

            target = points[_targetId].transform;
            #region CountAndReset

            _maxCount = points.Count;
            if (_targetId == _maxCount)
            {
                _targetId = 0;
            }

            #endregion
            // Debug.Log("i Still happen");
        }

        void MoveTo(Transform target)
        {
            
        }

        private void FixedUpdate()
        {
            if (!target && !targetReached)
            {
                SelectTarget();
            }
        }
    }

}