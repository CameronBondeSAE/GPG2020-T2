using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

public class Death : MonoBehaviour
{
    void Start()
    {
        GetComponent<HealthComponent>().deathEvent.AddListener(Dead);
    }
    
    public void Dead(HealthComponent arg0)
    {
        Destroy(gameObject);
    }
    
    public void OnDestroy()
    {
        GetComponent<HealthComponent>().deathEvent.RemoveListener(Dead);
    }
}
