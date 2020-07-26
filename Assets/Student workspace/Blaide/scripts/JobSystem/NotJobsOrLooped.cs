using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotJobsOrLooped : MonoBehaviour
{
    
    [Header("This  spawns cubes that move themselves.")]
    [Space]
    [Space]
    
    public GameObject ObjPrefab;
    public int objCount;

    public Transform[] transforms;

    // Start is called before the first frame update
    void Start()
    {
        transforms = new Transform[objCount];
        for (int i = 0; i < transforms.Length; i++)
        {
            GameObject g = Instantiate(ObjPrefab, transform.position + new Vector3( + i, 1, 1),
                transform.rotation);
            g.GetComponent<DumbCubeScript>().index = i;
            transforms[i] = g.transform;
        }
    }

}
