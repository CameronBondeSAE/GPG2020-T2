using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ColorPickerRGB : MonoBehaviour
{

    
    [Range(0,1)]
    public float red;
    [Range(0,1)]
    public float green;
    [Range(0,1)]
    public float blue;

    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    public Color color;

    public Image colorDisplay;
    
    // Create a custom unityEvent so i can pass a colour through it...
    [System.Serializable]
    public class UnityColorEvent : UnityEvent<Color> {}
    
    [SerializeField]
    public UnityColorEvent onValueChanged;

    void Start()
    {
        SetColor(color);
    }
    
    void UpdateColor()
    {
        color = new Color(red,green,blue,1);
        if (colorDisplay != null) colorDisplay.color = color;
        
        onValueChanged?.Invoke(color);
    }

    public void SetColor(Color colorIn)
    {
        red = colorIn.r;
        green = colorIn.g;
        blue = colorIn.b;
        
        redSlider.value = red;
        greenSlider.value = green;
        blueSlider.value = blue;
         UpdateColor();
    }

    public void UpdateR(float r)
    {
        red = r;
        UpdateColor();
    }

    public void UpdateG(float g)
    {
        green = g;
        UpdateColor();
    }
    
    public void UpdateB(float b)
    {
        blue = b;
        UpdateColor();
    }
}
