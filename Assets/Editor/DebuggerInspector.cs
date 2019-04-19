using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Debugger))]
public class DebuggerInspector : Editor
{
    bool prefabWindowOpen = false;
    bool spawnWindowOpen = false;

    public override void OnInspectorGUI()
    {
        Debugger debugger = target as Debugger;

        prefabWindowOpen = EditorGUILayout.Foldout(prefabWindowOpen, "Prefabs");
        if (prefabWindowOpen)
            DrawDefaultInspector();

        spawnWindowOpen = EditorGUILayout.Foldout(spawnWindowOpen, "Spawn");
        if (spawnWindowOpen)
        {
            if (GUILayout.Button("Spawn infantry"))
                debugger.Spawn(debugger.infantry);
            if (GUILayout.Button("Spawn helicopter"))
                debugger.Spawn(debugger.helicopter);
            if (GUILayout.Button("Spawn battleship"))
                debugger.Spawn(debugger.battleship);
        }
    }
}
