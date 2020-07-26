using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinneMeshColliderUpdater : MonoBehaviour
{
    
    SkinnedMeshRenderer meshRenderer;
    MeshCollider collider;
    
    public bool updateColliderOnStart = true;
    public bool updateColliderOnUpdate;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        collider = GetComponent<MeshCollider>();

        if (collider == null || meshRenderer == null)
        {
            updateColliderOnStart = false;
            updateColliderOnUpdate = false;
        }
        else if(updateColliderOnStart)
        {
            UpdateCollider();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (updateColliderOnUpdate)
        {
            UpdateCollider();
        }
    }
    

    
    public void UpdateCollider() {
        Mesh colliderMesh = new Mesh();
        meshRenderer.BakeMesh(colliderMesh);
        collider.sharedMesh = null;
        collider.sharedMesh = colliderMesh;
    }
}
