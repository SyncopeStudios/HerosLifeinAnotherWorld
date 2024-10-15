
    using System;
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(Waypoints))]
    public class WaypointEditor : Editor
    {
        private Waypoints _waypointsTarget => target as Waypoints;

        private void OnSceneGUI()
        {
            if(_waypointsTarget.Points.Length <= 0f) return;
            
            Handles.color = Color.red;
            for (int i = 0; i < _waypointsTarget.Points.Length; i++)
            {
                EditorGUI.BeginChangeCheck();

                Vector3 currentP = _waypointsTarget.EntityPosition + _waypointsTarget.Points[i];

                Vector3 newPosition =
                    Handles.FreeMoveHandle(currentP, 0.5f, Vector3.one * 0.5f, Handles.SphereHandleCap);

                GUIStyle text = new GUIStyle();
                text.fontStyle = FontStyle.Bold;
                text.fontSize = 16;
                text.normal.textColor = Color.black;
                Vector3 textPos = new Vector3(0.2f, 0.2f);
                Handles.Label(_waypointsTarget.EntityPosition + _waypointsTarget.Points[i] + textPos, $"{i+1}",text);
                
                
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(target,"Free Move");
                    _waypointsTarget.Points[i] = newPosition - _waypointsTarget.EntityPosition;
                }
            }
            
        }
    }
