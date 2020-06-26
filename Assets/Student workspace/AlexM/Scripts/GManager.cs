using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public event Action GM;
    // Start is called before the first frame update
    void Start()
    {
        GM?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
