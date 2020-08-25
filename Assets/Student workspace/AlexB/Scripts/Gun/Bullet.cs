using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class Bullet : MonoBehaviour
    {
        public float disappearTimer = 1.5f;
        public float bulletSpeed = 5.0f;
        public float dmg = 100f;
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
            GetComponent<Rigidbody>().velocity = transform.InverseTransformDirection(0,0, 10f); 
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "Enemy")
            {
                Destroy(collision.gameObject);
            }
        }

    }
}