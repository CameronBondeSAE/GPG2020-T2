using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public int thrustX, thrustY, thrustZ;



    public void OnCollisionEnter(Collision other)
    {
        Vector3 gameThrust = new Vector3(thrustX, thrustY, thrustZ);
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(gameThrust * 40, ForceMode.Acceleration);

        }

    }

}
