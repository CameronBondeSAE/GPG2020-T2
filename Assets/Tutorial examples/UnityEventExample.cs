using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventExample : MonoBehaviour
{
	public UnityEvent somethingHappenedUnityEvent;


    // Start is called before the first frame update
    void Start()
    {
        somethingHappenedUnityEvent.Invoke();
    }
}
