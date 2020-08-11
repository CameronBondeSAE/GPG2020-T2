using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class Slime : MonoBehaviour
    {
        private SlimeEnum _slimeEnum;
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

        /*private void Update()
        {          
            player.transform.position = transform.position;             
            Debug.Log(transform.position);
        }
        

        // Research other ways to update code in edit mode
      /*  void OnDrawGizmos()
        {
            Gizmos.DrawCube(transform.position, Vector3.one);
            GetComponent<Renderer>().material.color = gameObject.GetComponent<ColorChanger>().ChangeTo(SlimeEnum _slimeEnum);
        }*/
    }
}

