using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Respawnable : MonoBehaviour
{
    public UnityEvent onRespawn;
    public bool useCheckpoints = false;
    private Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    public void SetNewRespawnPoint(Vector3 v)
    {
        respawnPoint = v;
    }

    public void Respawn()
    {

        transform.position = respawnPoint;
        
        Rigidbody rB;
        if (TryGetComponent<Rigidbody>(out rB))
        {
            rB.velocity = Vector3.zero;
        }

        onRespawn.Invoke();
    }
}
