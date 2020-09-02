using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnthonyY
{
    public class ScaleUpDown : MonoBehaviour
    { 
        public float length = 3;
   
        void Update()
        {
            transform.localScale = new Vector3(Mathf.PingPong(Time.time,length),transform.localScale.y,transform.localScale.z);
        }
    }
}
