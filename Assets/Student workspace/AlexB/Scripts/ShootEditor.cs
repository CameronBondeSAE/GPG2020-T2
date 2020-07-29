using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.GlobalIllumination;

public class ShootEditor : Editor
{
    [CustomEditor(typeof(Shoot))]

    public class Shoot : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Shoot"))
            {
                //((Shoot)target);
            }
        }
    }
}
