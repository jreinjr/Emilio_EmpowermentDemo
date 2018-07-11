using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HoverButton))]
[CanEditMultipleObjects]
public class HoverButtonEditor : UnityEditor.UI.ButtonEditor {

    SerializedProperty onSelect;
    SerializedProperty onDeselect;
    SerializedProperty onPointerEnter;
    SerializedProperty onPointerExit;

    protected override void OnEnable()
    {
        base.OnEnable();
        onSelect = serializedObject.FindProperty("onSelect");
        onDeselect = serializedObject.FindProperty("onDeselect");
        onPointerEnter = serializedObject.FindProperty("onPointerEnter");
        onPointerExit = serializedObject.FindProperty("onPointerExit");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.PropertyField(onSelect);
        EditorGUILayout.PropertyField(onDeselect);
        EditorGUILayout.PropertyField(onPointerEnter);
        EditorGUILayout.PropertyField(onPointerExit);
        serializedObject.ApplyModifiedProperties();
    }
}
