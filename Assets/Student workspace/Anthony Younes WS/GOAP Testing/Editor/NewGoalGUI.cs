using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(ShootyGoapAgent))]
public class NewGoalGUI : Editor
{
  public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Calculate Goal"))
        {
           ((ShootyGoapAgent)target).CalculateNewGoal();
        }
    }
}
