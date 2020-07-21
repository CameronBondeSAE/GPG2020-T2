using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Mirror;

namespace alexM
{
    public class TriggerEvent : MonoBehaviour
    {
        public UnityEvent pressedEvent;

        // Start is called before the first frame update

        void OnTriggerEnter(Collider other)
        {
            pressedEvent.Invoke();
            Debug.Log("Button was triggered");
        }
    }

}