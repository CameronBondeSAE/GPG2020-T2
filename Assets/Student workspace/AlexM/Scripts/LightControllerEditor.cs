using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace alexM
{
    [CustomEditor(typeof(LightController))]
    public class LightControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Toggle"))
            {
                ((LightController) target).Toggle();
            }
            
            if (GUILayout.Button("On"))
            {
                ((LightController) target).TurnOn();
            }
            
            if (GUILayout.Button("Off"))
            {
                ((LightController) target).TurnOff();
            }
        }
    }
}
