using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class ColorChanger : MonoBehaviour
    {
        private Color previousColor;
        private Renderer renderer;

        private void Awake()
        {
            if (gameObject.GetComponent<Renderer>()!= null)
            {
                renderer = gameObject.GetComponent<Renderer>();                
            }
            else
            {
                Debug.Log("No renderer");
            }
        }
        public void ChangeTo(Color newColor)
        {
            Material mat = renderer.material;
            previousColor = mat.color;
            renderer.material.color = newColor;
        }
    }
}