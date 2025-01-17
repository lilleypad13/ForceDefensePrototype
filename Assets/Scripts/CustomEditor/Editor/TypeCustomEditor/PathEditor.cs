using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{
    private Path pathTarget;

    private void OnEnable()
    {
        pathTarget = (Path)target;
    }

    //protected virtual void OnSceneGUI()
    //{
    //    // Begin GUI Update
    //    EditorGUI.BeginChangeCheck();



    //    // End GUI Update
    //    if (EditorGUI.EndChangeCheck())
    //    {
    //        Undo.RecordObject(pathTarget, "Change path.");
    //    }
    //}

    public override void OnInspectorGUI()
    {
        // Base Inspector
        base.OnInspectorGUI();

        // Build Path Button
        if(GUILayout.Button("Rebuild Path", GUILayout.ExpandWidth(true), GUILayout.Height(30.0f)))
        {
            pathTarget.GeneratePath();
        }

        if (GUILayout.Button("Delete Path", GUILayout.ExpandWidth(true), GUILayout.Height(30.0f)))
        {
            pathTarget.ClearCurrentPath();
        }
    }
}
