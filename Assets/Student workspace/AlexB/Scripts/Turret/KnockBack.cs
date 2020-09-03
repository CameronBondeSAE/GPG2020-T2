using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using alexM;

namespace AJ
{
    public class KnockBack : MonoBehaviour
    {
        [SerializeField] private float knockbackStrength;
        private void OnCollisionEnter(Collision collision)
        {
            

            if (collision.transform.root.GetComponent<PlayerControllerTopDown>())
            {
                Rigidbody rb = collision.transform.root.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    Vector3 direction = collision.transform.position - transform.position;
                    direction.y = 0;

                    rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
                    
                }
                
            }
            Destroy(gameObject);
        }
    }
}