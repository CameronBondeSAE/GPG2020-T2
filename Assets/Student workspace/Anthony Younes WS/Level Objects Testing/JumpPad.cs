using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class JumpPad : NetworkBehaviour
{
    public int thrustX, thrustY, thrustZ;
    public void OnCollisionEnter(Collision other)
    {
        Vector3 gameThrust = new Vector3(thrustX, thrustY, thrustZ);
        if (isServer)
        { 
            if (other.gameObject.GetComponent<Rigidbody>() != null)
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(gameThrust, ForceMode.VelocityChange);

            }
            
        }
    }

}
