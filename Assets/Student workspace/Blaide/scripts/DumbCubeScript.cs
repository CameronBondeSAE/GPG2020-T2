using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DumbCubeScript : MonoBehaviour
{
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            transform.position = new Vector3(transform.position.x,
                5 * noise.cnoise(new float2(Time.time + (index * 0.1f), 1)), transform.position.z);
        
    }
}
