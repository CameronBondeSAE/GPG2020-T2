using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent pressed;

    // Start is called before the first frame update
    void Start()
    {
        pressed.Invoke();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            Debug.Log("Object has collided");
        }
    }   

  
}
