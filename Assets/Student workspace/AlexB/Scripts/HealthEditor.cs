using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.GlobalIllumination;


namespace AJ
{
    [CustomEditor(typeof(HealthComponent))]
    public class HealthEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Add HP"))
            {
                ((HealthComponent)target).AddHp(10);
            }

            if (GUILayout.Button("Take HP"))
            {
                ((HealthComponent)target).TakeHp(10);
            }

            if (GUILayout.Button("Death"))
            {
                ((HealthComponent)target).Death();
            }
        }
    }
}

