using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
  //  public float speed;
    public Transform FollowPos;
    public float force = 0.1f;


    public void Update()
    {
       // Quaternion rotTarget = Quaternion.LookRotation(FollowPos.position - this.transform.position);
      //  this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, speed * Time.deltaTime);

      Vector3 targetDelta = FollowPos.position - transform.position;

      float angleDiff = Vector3.Angle(transform.forward, targetDelta);

      Vector3 cross = Vector3.Cross(transform.forward, targetDelta);

      GetComponent<Rigidbody>().AddTorque(cross * (angleDiff * force));
    }
}
