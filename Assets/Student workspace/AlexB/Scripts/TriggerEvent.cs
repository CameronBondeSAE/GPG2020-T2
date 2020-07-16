using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Mirror;

public class TriggerEvent : NetworkBehaviour
{
    public UnityEvent pressedEvent;

    // Start is called before the first frame update
   
    void OnTriggerEnter(Collider other)
    {
        if (isServer)
        {
            //if (other.CompareTag("Object"))
            {
                pressedEvent.Invoke();
                Debug.Log("Object has collided");
            }
        }        
    }     
}
