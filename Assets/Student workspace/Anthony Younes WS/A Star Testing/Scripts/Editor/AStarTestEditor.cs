using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AStarTest))]
public class AStarTestEditor : Editor
{
	void OnSceneGUI()
	{
		Handles.color = Color.green;
		AStarTest aStar = (AStarTest) target;
		Handles.FreeMoveHandle(aStar.transform.position, aStar.transform.rotation, aStar.nodeRadius, Vector3.right,
							   Handles.CubeHandleCap);


	}
}