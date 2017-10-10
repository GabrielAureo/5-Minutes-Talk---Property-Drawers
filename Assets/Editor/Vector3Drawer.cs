using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Vector3))]
public class TestEditor : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
		SerializedProperty x = property.FindPropertyRelative("x");
		SerializedProperty y = property.FindPropertyRelative("y");
		SerializedProperty z = property.FindPropertyRelative("z");

		EditorGUI.BeginProperty(position,label,property);


		var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		EditorGUIUtility.labelWidth = 14.0f;
		var xRect = new Rect(position.x, position.y, 72, EditorGUIUtility.singleLineHeight);
		var yRect = new Rect(xRect.xMax, position.y, 72, EditorGUIUtility.singleLineHeight);
		var zRect = new Rect(yRect.xMax, position.y, 72, EditorGUIUtility.singleLineHeight);
		var copyRect = new Rect(zRect.xMax, position.y, 30, EditorGUIUtility.singleLineHeight);
		var pasteRect = new Rect(copyRect.xMax, position.y, 30, EditorGUIUtility.singleLineHeight);

		EditorGUI.PropertyField(xRect, x, new GUIContent("X"));
        EditorGUI.PropertyField(yRect, y, new GUIContent("Y"));
        EditorGUI.PropertyField(zRect, z, new GUIContent("Z"));

		EditorGUIUtility.fieldWidth = 0; //Retorna pro padrão

		if(GUI.Button(copyRect, "C")){
			EditorPrefs.SetFloat("X", x.floatValue);
			EditorPrefs.SetFloat("Y", y.floatValue);
			EditorPrefs.SetFloat("Z", z.floatValue);
		}

		if(GUI.Button(pasteRect, "P")){
			x.floatValue = EditorPrefs.GetFloat("X",0.0f);
			y.floatValue = EditorPrefs.GetFloat("Y",0.0f);
			z.floatValue = EditorPrefs.GetFloat("Z",0.0f);
		}
		

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label){
		return EditorGUIUtility.singleLineHeight;
	}
}
