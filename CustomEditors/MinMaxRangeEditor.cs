using System;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Anna;

[CustomPropertyDrawer(typeof(MinMaxRange))]
public class MinMaxRangeEditor : PropertyDrawer {
    //bool foldout = false;
    
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
        //base.OnGUI(position, property, label);
        
        var minVal = property.FindPropertyRelative("min");
        var maxVal = property.FindPropertyRelative("max");

        EditorGUILayout.Space(-20);

        //foldout = EditorGUILayout.Foldout(foldout, "");
        
        //if(foldout){
            minVal.floatValue = EditorGUILayout.Slider("min", minVal.floatValue, 0, maxVal.floatValue-0.1f);
            maxVal.floatValue = EditorGUILayout.Slider("max", maxVal.floatValue, minVal.floatValue+0.1f, maxVal.floatValue+100);
        //}
    }
}