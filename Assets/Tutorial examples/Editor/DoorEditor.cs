using System.Collections;
using System.Collections.Generic;
using Cam;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Door))]
public class DoorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		
		if (GUILayout.Button("Open"))
		{
			Debug.Log("OPEN");
			
			// CASTING.
			// Is this 'target' variable ACTUALLY A DOOR? If it is, do Door stuff
			//
			// This 'target' variable is of type "Object"
			// Door inherits from 'Object'
			// I want to do door specific things,
			// BUT 'target' ISN'T set to point to a door, just a generic object
			// So you can hint to Unity that it's ok to treat 'target' as a Door,
			// because Door inherits from the same type "Object"
			
			((Door)target).Open();
		}
		
	}
}
