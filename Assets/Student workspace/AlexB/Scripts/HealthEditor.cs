using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.GlobalIllumination;



[CustomEditor(typeof(HealthComponent))]
public class HealthEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Add HP"))
        {
            ((HealthComponent)target).AddHp();
        }

        if(GUILayout.Button("Take HP"))
        {
            ((HealthComponent)target).TakeHp();
        }
    }
}
