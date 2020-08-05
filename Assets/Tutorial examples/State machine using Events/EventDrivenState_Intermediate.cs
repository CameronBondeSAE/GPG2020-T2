using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class EventDrivenState_Intermediate : MonoBehaviour
{
	public EventState idle = new EventState();
	public EventState run  = new EventState();

	public EventStateManager EventStateManager = new EventStateManager();

	// Start is called before the first frame update
	void Start()
	{
		// Here I'm using "Lambdas" so I don't have to define whole functions for everything. You can mix and match.
		idle.Enter   = () => Debug.Log("IDLE BEGIN");
		idle.Execute = () => Debug.Log("IDLE GO!");
		idle.Exit    = () => Debug.Log("IDLE END");

		run.Enter   = () => Debug.Log("run begin");
		run.Execute = () => Debug.Log("run execute");

		EventStateManager.ChangeState(idle);
	}

	// Update is called once per frame
	void Update()
	{
		EventStateManager.ExecuteCurrentState();

		// Just me forcing the state to change for testing
		if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
		{
			EventStateManager.ChangeState(run);
		}
	}
}

[CustomPropertyDrawer(typeof(EventState))]
public class EventStateEditor : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		// base.OnGUI(position, property, label);

		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty(position, label, property);

		// Draw label
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		// Don't make child fields be indented
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		// Calculate rects
		var amountRect = new Rect(position.x, position.y, 30, position.height);
		// var unitRect   = new Rect(position.x + 35, position.y, 50,                  position.height);
		// var nameRect   = new Rect(position.x + 90, position.y, position.width - 90, position.height);

		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("active"), GUIContent.none);

		// Set indent back to what it was
		EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}
}