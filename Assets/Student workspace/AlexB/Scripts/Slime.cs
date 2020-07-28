using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class Slime : MonoBehaviour
    {
        //hello, test
        private Color myColor;
        private void Awake()
        {
            myColor = gameObject.GetComponent<Renderer>().material.color;
        }
        void OnTriggerEnter(Collider other)
        {
            //Debug.Log(transform.name.ToString() +  " Hello");
            if (other.gameObject.GetComponent<ColorChanger>())
            {
                other.gameObject.GetComponent<ColorChanger>().ChangeTo(myColor);
            }
        }
    }
}

