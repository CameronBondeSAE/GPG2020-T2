using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(AStarTest))]
public class DynamicNodeGUI : Editor
{
    private AStarTest astar;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        AStarTest myscript = (AStarTest) target;

        if (GUILayout.Button("ReScan Nodes"))
        {
            myscript.CreateNodes(0,myscript.gridSize.x,0,myscript.gridSize.y);
        }
        base.OnInspectorGUI();
    }
}
