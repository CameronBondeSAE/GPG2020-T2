using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [Header("This Uses ECS / DOTs")]
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
            GameObject g = Instantiate(ObjPrefab, transform.position + new Vector3( i, 1, 1),
                transform.rotation);
            
           // g.GetComponent<CubeComponentData>().index = i;
            transforms[i] = g.transform;
        }
    }

}


public interface IColorChanger
{
    void changedColor( Color Color);
}

public class thing : IColorChanger
{
    public void changedColor(Color Color)
    {
        
    }
}