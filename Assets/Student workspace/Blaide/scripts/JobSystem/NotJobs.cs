using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

public class NotJobs : MonoBehaviour
{
    public GameObject ObjPrefab;
    public int objCount;

    public Transform[] transforms;

    // Start is called before the first frame update
    void Start()
    {
        transforms = new Transform[objCount];
        for (int i = 0; i < transforms.Length; i++)
        {
            GameObject g = Instantiate(ObjPrefab, transform.position + new Vector3(   i, 1, 1),
                transform.rotation);

            transforms[i] = g.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (var index = 0; index < transforms.Length; index++)
        {
            Transform t = transforms[index];
            t.position = new Vector3(t.position.x,
                5 * noise.cnoise(new float2(Time.time + (index * 0.1f), 1)), t.position.z);
        }
    }
}
