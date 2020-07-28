﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(UnitMovement))]
public class RecalculatePathGUI : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        UnitMovement myscript = (UnitMovement) target;

        if (GUILayout.Button("ReCalculate Path"))
        {
            myscript.RecalculatePath();
        }
        base.OnInspectorGUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
