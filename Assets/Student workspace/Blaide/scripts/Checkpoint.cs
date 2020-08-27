using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Checkpoint : MonoBehaviour
{
    public Vector3 point;

    public UnityEvent reached;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Respawnable res;
        Component comp;

            if (other.gameObject.transform.root.TryGetComponent(typeof(Respawnable), out comp))
            {
                
                res = (Respawnable) comp;
                if (res.useCheckpoints)
                {
                    res.SetNewRespawnPoint(transform.position);
                    reached.Invoke();
                }
            }
    }
}
