using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class CamBullet : MonoBehaviour
    {
        public float disappearTimer = 1.5f;
        IEnumerator Disappear()
        {
            yield return new WaitForSeconds(disappearTimer);
            Destroy(gameObject);
        }

        void Awake()
        {
            StartCoroutine("Disappear");
        }

		private void Start()
		{
			GetComponent<Rigidbody>().velocity = transform.InverseTransformDirection(0, 0, 10f);
		}

		private void Update()
		{
			Debug.DrawRay(transform.position, GetComponent<Rigidbody>().velocity, Color.green, 1f);
		}
	}
}