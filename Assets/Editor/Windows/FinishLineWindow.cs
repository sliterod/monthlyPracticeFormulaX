using UnityEngine;
using System.Collections;
using UnityEditor;

public class FinishLineWindow : EditorWindow {

    [MenuItem("SceneObjects/Add FINISH LINE to Scene")]
    static void Init()
    {
        Debug.Log("Adding FinishLine Object to current scene");
        AddObject.AddFinishLine();
    }
}
