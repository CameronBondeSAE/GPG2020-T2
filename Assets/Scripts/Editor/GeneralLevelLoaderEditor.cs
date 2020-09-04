using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GeneralLevelLoader))]
public class GeneralLevelLoaderEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if (GUILayout.Button("Next"))
		{
			(target as GeneralLevelLoader)?.LoadLevel();
		}
	}
}