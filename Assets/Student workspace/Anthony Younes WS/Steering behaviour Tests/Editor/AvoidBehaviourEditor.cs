using AnthonyY;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AvoidBehaviour))]
public class AvoidBehaviourEditor : Editor
{
	void OnSceneGUI()
	{
		Handles.color = Color.red;
		if (target != null)
		{
			AvoidBehaviour avoidBehaviour = (AvoidBehaviour) target;
			Handles.DrawSolidArc(avoidBehaviour.transform.position, avoidBehaviour.transform.forward, avoidBehaviour.transform.forward, avoidBehaviour.turnSpeed, avoidBehaviour.distance);
			Handles.color           = Color.white;
			avoidBehaviour.distance = (float) Handles.ScaleValueHandle(avoidBehaviour.distance, avoidBehaviour.transform.position + avoidBehaviour.transform.forward * avoidBehaviour.distance, avoidBehaviour.transform.rotation, 1, Handles.ConeHandleCap, 1);
		}
	}
}
