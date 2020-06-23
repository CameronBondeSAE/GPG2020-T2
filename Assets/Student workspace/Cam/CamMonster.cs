using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMonster : MonoBehaviour
{
	public Animator animator;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// TODO: Put in the real player distance (multiple players?)
        animator.SetFloat("DistanceToPlayer", Vector3.Distance(transform.position, Vector3.zero));
    }
}
