using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace alexM
{
    [CustomEditor(typeof(Door))]
    public class DoorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Open"))
            {
                ((Door)target).Open();
            }
        }
    }

}