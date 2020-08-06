using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Speed : MonoBehaviour
{
    public bool GimmeRigidBody;
    public Rigidbody rb;
    private Vector3 previousPosition;

    [SerializeField]
    private float speed;

    public float Speed1
    {
        get
        {
            if (!rb)
            {
                if (GimmeRigidBody)
                {
                    if (!gameObject.GetComponent<Rigidbody>())
                    {
                        gameObject.GetComponent<Rigidbody>();
                        rb = gameObject.GetComponent<Rigidbody>();
                        rb.constraints = RigidbodyConstraints.FreezeRotationX;
                        rb.constraints = RigidbodyConstraints.FreezePositionZ;
                    
                    }
                    else
                    {
                        if (gameObject.GetComponent<Rigidbody>())
                        {
                            rb = gameObject.GetComponent<Rigidbody>();
                        }
                    }
                        

                    speed = (previousPosition - transform.position).magnitude/Time.deltaTime;
                    previousPosition = transform.position;
                    
                }
            }
             return speed;
        }
        set
        {
            speed = value;
        } 
    }
    
}
