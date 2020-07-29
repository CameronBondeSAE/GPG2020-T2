using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class Bullet : MonoBehaviour
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
    }
}