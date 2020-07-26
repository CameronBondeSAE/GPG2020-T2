using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
     private Color previousColor;
     private Renderer renderer;

    private void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }
    public void ChangeTo(Color newColor)
     {
        previousColor = renderer.material.color;
        renderer.material.color = newColor;
     }
}
