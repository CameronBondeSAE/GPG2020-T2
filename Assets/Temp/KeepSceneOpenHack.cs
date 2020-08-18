using UnityEngine;

// This forces the scene you attach this to, to stay open and NOT FOLD UP, when you load other scenes.
public class KeepSceneOpenHack : MonoBehaviour
{
	void Awake()
	{
#if UNITY_EDITOR
		UnityEditor.EditorGUIUtility.PingObject(gameObject);
#endif
	}
}
