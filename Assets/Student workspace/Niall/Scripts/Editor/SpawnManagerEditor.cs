using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Niall
{
    [CustomEditor(typeof(SpawnManager))]
    public class SpawnManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Spawn"))
            {
                ((SpawnManager)target).SpawnAll();
                Debug.Log("Spawned Via Inspector Button.");
            }


            if (GUILayout.Button("Destroy All Enemies"))
            {
                ((SpawnManager)target).KillAll();
            }
        }
    }
}
