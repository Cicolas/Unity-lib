using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Plane))]
public class PlaneCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Plane plane = (Plane)target;
        
        base.OnInspectorGUI();
        if (GUILayout.Button("Update"))
        {
            plane.CreateQuad();
        }
    }
}
